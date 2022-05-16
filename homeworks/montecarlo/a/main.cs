using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		vector a = new vector(0, 0, 0);
		vector b = new vector(PI, PI, PI);
		
		vector a1 = new vector(0, 0);
		vector b1 = new vector(1, 1);

		Func<vector, double> f1 = v => v[0]*v[0] + v[1]*v[1];
		(double res1, double err1) = MonteCarlo.plainmc(f1, a1, b1, 1000000);
		WriteLine($"int_0^1 dx int_0^1 dy x^2 + y^2 = {res1}, should be 2/3, with error {err1}");

		Func<vector, double> f2 = v => Log(v[0]) * v[1];
		(double res2, double err2) = MonteCarlo.plainmc(f2, a1, b1, 1000000);
		WriteLine($"int_0^1 dx int_0^1 dy Log(x)*y = {res2}, should be -1/2, with error {err2}");

		Func<vector, double> f = v => 1/(1 - Cos(v[0])*Cos(v[1])*Cos(v[2]))/PI/PI/PI;
		(double res, double err) = MonteCarlo.plainmc(f, a, b, 1000000);
		WriteLine($"int_0^pi dx/pi int_0^pi dy/pi int_0^pi dz/pi [1 - cos(x)cos(y)cos(z)]^-1 = {res}, should be 1.393203929... with error {err}");
		return 0;
	}
}
