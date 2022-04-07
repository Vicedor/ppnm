using System;
using static System.Console;
using static System.Math;
using static System.Double;

public static class main{
	public static int Main(String[] args) {
		int i = 0;
		int j = 0;
		int k = 0;
		Func<double, double> gauss = x => {i++; return Exp(-x*x);};
		Func<double, double> xinv = x => {j++; return 1/(x*x);};
		Func<double, double> xsqrd = x => {k++; return 1/(1+x*x);};
		(double r1, double er1) = Integrate.integrate(gauss, NegativeInfinity, PositiveInfinity);
		(double r2, double er2) = Integrate.integrate(xinv, 1, PositiveInfinity);
		(double r3, double er3) = Integrate.integrate(xsqrd, NegativeInfinity, 0);
		WriteLine($"int_-inf^inf e^(-x^2) dx = {r1}, should be {Sqrt(PI)}. Error: {er1}. Number of function calls: {i}.");
		WriteLine($"int_1^inf tan(x)/x dx = {r2}, should be {1}. Error: {er2}. Number of function calls {j}.");
		WriteLine($"int_-inf^0 1/(1+x^2) dx = {r3}, should be {PI/2}. Error: {er3}. Number of function calls {k}.");
		return 0;
	}
}
