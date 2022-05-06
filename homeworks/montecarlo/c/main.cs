using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		vector a = new vector(0, 0);
		vector b = new vector(1, 1);
		Func<vector, double> f = v => {if (v[0]*v[0]+v[1]*v[1] < 0.8*0.8) return 1; else return 0;};
		(double res, double err) = MonteCarlo.stratmc(f, a, b, 1000);
		WriteLine($"int_0^1 dx int_0^1 dy 1 if x^2 + y^2 < 0.8^2 else 0 = {res}, should be 0.5026548... with error {err}");
		return 0;
	}
}
