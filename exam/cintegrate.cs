using System;
using static System.Math;
using static cmath;
using static complex;
using static System.Double;

public static class ComplexIntegrate {
	public static (complex, double) IntegrateIterator(Func<complex, complex> f, complex a, complex b,
		                   	                   complex f2, complex f3, double acc=0.001, double eps=0.001) {
		complex h = b-a;
		
		complex f1 = f(a + h/6);
		complex f4 = f(a + 5*h/6);
		complex Q = (2*f1 + f2 + f3 + 2*f4)/6 * (b - a);
		complex q = (  f1 + f2 + f3 +   f4)/4 * (b - a);
		double err = magnitude(Q - q);
		if (err <= Max(acc, magnitude(Q) * eps)) {
			return (Q, err);
		}
		else {
			(complex r1, double e1) = IntegrateIterator(f, a, (a+b)/2, f1, f2, acc/Sqrt(2), eps);
			(complex r2, double e2) = IntegrateIterator(f, (a+b)/2, b, f3, f4, acc/Sqrt(2), eps);
			return (r1 + r2, Sqrt(e1*e1 + e2*e2));
		}
	}

	public static (complex, double) Integrate(Func<complex, complex> f, complex a, complex b,
						   double acc=0.001, double eps=0.001) {
		complex h = b - a;
		complex f2 = f(a + 2*h/6);
		complex f3 = f(a + 4*h/6);
		return IntegrateIterator(f, a, b, f2, f3, acc:acc, eps:eps);
	}

	public static (complex, double) VT_Integrate(Func<complex, complex> f, complex a, complex b,
			                              double acc=0.001, double eps=0.001) {
		Func<complex, complex> f_transform = (theta => f((a+b)/2 + (b-a)/2 * cos(theta)) * sin(theta) * (b-a)/2);
		return Integrate(f_transform, 0, PI, acc:acc, eps:eps);
	}

	public static (complex, double) Integrate(Func<double, complex> f, double a, double b,
						   double acc=0.001, double eps=0.001) {
		Func<complex, complex> ft = z => f(z.Re);
		return Integrate(ft, new complex(a, 0), new complex(b, 0), acc:acc, eps:eps);
	}

	public static (complex, double) VT_Integrate(Func<double, complex> f, double a, double b,
						      double acc=0.001, double eps=0.001) {
		Func<complex, complex> ft = z => f(z.Re);
		return VT_Integrate(ft, new complex(a, 0), new complex(b, 0), acc:acc, eps:eps);
	}

	public static (complex, double) ContourIntegrate(Func<complex, complex> f, Func<double, complex> z,
					     Func<double, complex> dzdt, double a, double b,
					     double acc=0.001, double eps=0.001) {
		
		Func<double, complex> fz_dzdt = t => f(z(t)) * dzdt(t);
		//Func<double, double> f_re = t => fz_dzdt(t).Re;
		//Func<double, double> f_im = t => fz_dzdt(t).Im;
		
		//(double res_re, double err_re) = Integrate.VT_integrate(f_re, a, b, acc:acc, eps:eps);
		//(double res_im, double err_im) = Integrate.VT_integrate(f_im, a, b, acc:acc, eps:eps);
		
		(complex res, double err) = VT_Integrate(fz_dzdt, a, b, acc:acc, eps:eps);

		//complex res = new complex(res_re, 0);//res_im);
	       	//complex err = new complex(err_re, 0);//err_im);
		return (res, err);
	}

	public static (complex, double) ComplexLineIntegrate(Func<complex, complex> f, complex a, complex b,
							      double acc=0.001, double eps=0.001) {
		// t goes from 0 to 1
		Func<double, complex> z = t => a + (b-a)*t;
		Func<double, complex> dzdt = t => b-a;

		return ContourIntegrate(f, z, dzdt, 0, 1, acc:acc, eps:eps);
	}
}
