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
	}

	private static (complex, complex) J(int n, double x) {
		Func<complex, complex> f = y => y.pow(-n-1) * exp(x*(y - 1.0/y)/2.0);
		Func<double, complex> z = t => exp(I*t);
		Func<double, complex> dzdt = t => I*exp(I*t);
		
		//Func<complex, complex> f = t => exp(I*x*sin(t));
		
		(complex res, complex err) = ComplexIntegrate.ContourIntegrate(f, z, dzdt, 0.0, 2*PI);
		
		//(complex res, complex err) = ComplexIntegrate.ComplexLineIntegrate(f, 0, 2*PI);
		return (res/(2*PI*I), err);
		
		//Func<double, complex> f = t => exp(I*x*sin(t))/(exp((n+1)*I*t))*I*exp(I*t); //exp(I*(n*t - x* Sin(t)));
		//(complex res, complex err) = ComplexIntegrate.CIntegrate(f, 0, 2*PI);
		//return (res/(2*PI*I), err);
	}

	private static void BesselPlot() {
		for (int n=0; n<=3; n++) {
			for (double x=0.0; x<20; x+=1/32.0) {
				(complex res, complex err) = J(n, x);
				Error.WriteLine($"{x} {res.Re} {err.Re}");
			}
			Error.WriteLine();
			Error.WriteLine();
		}
	}
}
