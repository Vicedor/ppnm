using System;
using static System.Console;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		vector a = new vector(0, 0, 0);
		vector b = new vector(PI, PI, PI);
		Func<vector, double> f = v => 1/(1 - Cos(v[0])*Cos(v[1])*Cos(v[2]))/PI/PI/PI;
		(double res1, double err1) = MonteCarlo.plainmc(f, a, b, 1000000);
		(double res2, double err2) = MonteCarlo.quasimc(f, a, b, 1000000);
		WriteLine("Using plain monte carlo:");
		WriteLine($"int_0^pi dx/pi int_0^pi dy/pi int_0^pi dz/pi [1 - cos(x)cos(y)cos(z)]^-1 = {res1}, should be 1.393203929... with error {err1}");
		WriteLine("Using quasi-random monte carlo:");
		WriteLine($"int_0^pi dx/pi int_0^pi dy/pi int_0^pi dz/pi [1 - cos(x)cos(y)cos(z)]^-1 = {res2}, should be 1.393203929... with error {err2}");

		for (int N=10; N<1000; N+=50) {
			double res3 = 0;
			double err3 = 0;
			double res4 = 0;
			double err4 = 0;
			int k = 1;
			for (int i=0; i<k; i++) {
				(double res3_temp, double err3_temp) = MonteCarlo.plainmc(f, a, b, N);
				(double res4_temp, double err4_temp) = MonteCarlo.quasimc(f, a, b, N);
				res3 += res3_temp;
				err3 += err3_temp;
				res4 += res4_temp;
				err4 += err4_temp;
			}
			res3 /= k;
			err3 /= k;
			res4 /= k;
			err4 /= k;
			Error.WriteLine($"{N} {res3} {err3} {res4} {err4}");
		}
		return 0;
	}
}
