using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		vector a = new vector(0, 0, 0);
		vector b = new vector(PI, PI, PI);
		Func<vector, double> f = v => 1/(1 - Cos(v[0])*Cos(v[1])*Cos(v[2]))/PI/PI/PI;
		(double res, double err) = MonteCarlo.plainmc(f, a, b, 1000000);
		WriteLine($"int_0^pi dx/pi int_0^pi dy/pi int_0^pi dz/pi [1 - cos(x)cos(y)cos(z)]^-1 = {res}, should be 1.393203929... with error {err}");
		return 0;
	}
}
