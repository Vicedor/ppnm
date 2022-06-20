using System;

public static class ComplexIntegrate {
	public static (complex, complex) ContourIntegrate(Func<complex, complex> f, Func<double, complex> z,
					     Func<double, complex> dzdt, double a, double b,
					     double acc=0.001, double eps=0.001) {
		
		Func<double, complex> fz_dzdt = t => f(z(t)) * dzdt(t);
		Func<double, double> f_re = t => fz_dzdt(t).Re;
		Func<double, double> f_im = t => fz_dzdt(t).Im;
		
		(double res_re, double err_re) = Integrate.VT_integrate(f_re, a, b, acc:acc, eps:eps);
		(double res_im, double err_im) = Integrate.VT_integrate(f_im, a, b, acc:acc, eps:eps);
		
		complex res = new complex(res_re, res_im);
	       	complex err = new complex(err_re, err_im);
		return (res, err);
	}

	public static (complex, complex) ComplexLineIntegrate(Func<complex, complex> f, complex a, complex b,
							      double acc=0.001, double eps=0.001) {
		// t goes from 0 to 1
		Func<double, complex> z = t => a + (b-a)*t;
		Func<double, complex> dzdt = t => b-a;

		return ContourIntegrate(f, z, dzdt, 0, 1, acc:acc, eps:eps);
	}

	public static (complex, complex) CIntegrate(Func<double, complex> f, double a, double b,
						    double acc=0.001, double eps=0.001) {
		Func<double, double> f_re = t => f(t).Re;
		Func<double, double> f_im = t => f(t).Im;
		(double res_re, double err_re) = Integrate.VT_integrate(f_re, a, b, acc:acc, eps:eps);
		(double res_im, double err_im) = Integrate.VT_integrate(f_im, a, b, acc:acc, eps:eps);

		complex res = new complex(res_re, res_im);
		complex err = new complex(err_re, err_im);
		return (res, err);
	}

}
