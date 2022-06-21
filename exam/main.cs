using System;
using static System.Console;
using static System.Math;
using static System.Double;
using static complex;
using static cmath;

public static class main{
	public static void Main(String[] args) {
		Func<complex, complex> f0 = x => x*x.conj();
		(complex res0, complex err0) = ComplexIntegrate.ComplexLineIntegrate(f0, -1.0, I);
		WriteLine($"Integral of f(z) = z^2 over straight line from -1 to i = {res0}, should be 2/3 + 2i/3, with err={err0}");

		DeltaFunction();

		Func<complex, complex> f1 = x => x.conj();
		Func<double, complex> z1 = t => 3*t + I*t*t;
		Func<double, complex> dzdt1 = t => 3 + 2*I*t;
		(complex res1, complex err1) = ComplexIntegrate.ContourIntegrate(f1, z1, dzdt1, -1.0, 4.0);
		WriteLine($"Integral of f(z) = conj(z) over z(t) = 3t+it^2 = {res1}, should be 195+65i, with err={err1}");

		Func<complex, complex> f2 = x => 1/x;
		Func<double, complex> z2 = t => exp(I*t);
		Func<double, complex> dzdt2 = t => I*z2(t);
		(complex res2, complex err2) = ComplexIntegrate.ContourIntegrate(f2, z2, dzdt2, 0, 2*PI);
		WriteLine($"Integral of f(z) = 1/z over z(t) = e^(i*t) = {res2}, should be 2*pi*i, with err={err2}");
		
		Func<complex, complex> f3 = x =>x*x.conj();
		Func<double, complex> z3 = t => exp(I*t);
		Func<double, complex> dzdt3 = t => I*exp(I*t);
		(complex res3, complex err3) = ComplexIntegrate.ContourIntegrate(f3, z3, dzdt3, PI, PI/2);
		WriteLine($"Integral of f(z) = z^2 over z(t) = e^(i*t) from pi to pi/2 = {res3}, should be 1 + i, with err={err3}");

		BesselPlot();

		TestFourierTransform();
		QuantumFreeParticle();
	}

	private static void DeltaFunction() {
		complex a = new complex(-1, -1);
		complex b = new complex(1, 1);
		for (double Delta=5.0; Delta > 0; Delta-=1.0/8) {
			Func<complex, complex> delta = x => exp(-x*x/(4*I*Delta*Delta)) / sqrt(4*PI*I*Delta*Delta);
			(complex res, double err) = ComplexIntegrate.ComplexLineIntegrate(delta, a, b, 1e-8, 1e-8);
			Error.WriteLine($"{Delta} {res.Re} {err}");
		}
		Error.WriteLine();
		Error.WriteLine();
	}

	private static (complex, complex) J(int n, double x) {
		Func<complex, complex> f = y => y.pow(-n-1) * exp(x*(y - 1.0/y)/2.0);
		Func<double, complex> z = t => exp(I*t);
		Func<double, complex> dzdt = t => I*exp(I*t);
		(complex res, complex err) = ComplexIntegrate.ContourIntegrate(f, z, dzdt, 0.0, 2*PI);
		return (res/(2*PI*I), err);
		
		//Func<double, complex> f = t => exp(I*(n*t - x* Sin(t)));
		//(complex res, complex err) = ComplexIntegrate.VT_Integrate(f, 0, 2*PI);
		//return (res/(2*PI), err);
		
		//complex res = integrator.vt_integrate(f, new complex(0, 0), new complex(2*PI, 0));
		//return (res/(2*PI*I), new complex());
	}

	private static void BesselPlot() {
		for (int n=0; n<=3; n++) {
			for (double x=0.0; x<10; x+=1.0/8) {
				(complex res, complex err) = J(n, x);
				Error.WriteLine($"{x} {res.Re} {err}");
			}
			Error.WriteLine();
			Error.WriteLine();
		}
	}

	private static void TestFourierTransform() {
		Func<double, double> gauss = x => Exp(-x*x);
		Func<double, complex> fourier_gauss = FourierTransform(gauss);
		for (double x = -5; x <= 5; x += 1.0/8) {
			Error.WriteLine($"{x} {gauss(x)} {fourier_gauss(x).Re}");
		}
		Error.WriteLine();
		Error.WriteLine();
	}

	private static void QuantumFreeParticle() {
		double kappa = 0.2;
		double Omega = 1;
		Func<double, double> f = t => Exp(-kappa*Abs(t))*Cos(Omega*t);
		Func<double, complex> ft = FourierTransform(f);
		for (double x = -15; x <= 15; x += 1.0/16) {
			Error.WriteLine($"{x} {f(x)} {ft(x).Re}");
		}
	}

	private static Func<double, complex> FourierTransform(Func<double, double> f) {
		Func<double, Func<double,complex>> g = p => x => f(x) * exp(-I*p*x) / Sqrt(2*PI);
		return z => {(complex res, double err) = ComplexIntegrate.Integrate(g(z), NegativeInfinity, PositiveInfinity);
			     return res;};
	}
}
