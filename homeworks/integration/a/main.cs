using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		double a = 0;
		double b = 1;
		Func<double, double> sqrtx = (x => Sqrt(x));
		Func<double, double> invsqrtx = (x => 1/Sqrt(x));
		Func<double, double> sqrtxsqrd = (x => 4*Sqrt(1 - x*x));
		Func<double, double> lnxsqrtx = (x => Log(x)/Sqrt(x));
		WriteLine($"int_0^1 dx sqrt(x) = {Integrate.integrate(sqrtx, a, b)} should be 2/3");
		WriteLine($"int_0^1 dx 1/sqrt(x) = {Integrate.integrate(invsqrtx, a, b)} should be 2");
		WriteLine($"int_0^1 dx 4sqrt(1 - x^2) = {Integrate.integrate(sqrtxsqrd, a, b)} should be pi");
		WriteLine($"int_0^1 dx ln(x)/sqrt(x) = {Integrate.integrate(lnxsqrtx, a, b)} should be -4");

		for (double x=-3; x <= 3; x+=1.0/8) {
			Error.WriteLine($"{x} {erf(x)}");
		}
		return 0;
	}

	private static double erf(double z) {
		Func<double, double> f = (x => Exp(-x*x));
		double result = Integrate.integrate(f, 0, z, acc:1e-6, eps:0);
		return result*2/Sqrt(PI);
	}
}
