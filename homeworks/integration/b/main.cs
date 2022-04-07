using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		double a = 0;
		double b = 1;
		int i=0;
		int j=0;
		Func<double, double> invsqrtx = x => {i++;return 1/Sqrt(x);};
		Func<double, double> lnxsqrtx = x => {j++;return Log(x)/Sqrt(x);};
		WriteLine("Using normal quadrature function:");
		WriteLine($"int_0^1 dx 1/sqrt(x) = {Integrate.integrate(invsqrtx, a, b)} should be 2. Number of calls to f: {i}");
		WriteLine($"int_0^1 dx ln(x)/sqrt(x) = {Integrate.integrate(lnxsqrtx, a, b)} should be -4. Number of calls to f: {j}");
		WriteLine("Using Clenshaw-Curtis variable transformation:");
		i = 0;
		j = 0;
		WriteLine($"int_0^1 dx 1/sqrt(x) = {Integrate.VT_integrate(invsqrtx, a, b)} should be 2. Number of calls to f: {i}");
		WriteLine($"int_0^1 dx ln(x)/sqrt(x) = {Integrate.VT_integrate(lnxsqrtx, a, b)} should be -4. Number of calls to f: {j}");
		return 0;
	}
}
