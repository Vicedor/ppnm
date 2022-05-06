using System;
using static System.Math;
using static System.Random;

public static class MonteCarlo {
	public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N) {
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++) {
			V*= b[i] - a[i];
		}
		double sum1 = 0;
		double sum2 = 0;
		vector x = new vector(dim);
		Random rnd = new Random();
		for (int i = 0; i<N; i++) {
			for (int j=0; j<dim; j++) {
				double r = rnd.NextDouble();
				x[j] = a[j] + r * (b[j] - a[j]);
				Console.Error.WriteLine($"{x[0]} {x[1]}");
			}
			double fx = f(x);
			sum1 += fx;
			sum2 += fx*fx;
		}
		double mean = sum1/N;
		double sigma = Sqrt(sum2/N - mean*mean);
		return (mean*V, sigma*V/Sqrt(N));
	}

	public static (double, double) stratmc(Func<vector, double> f, vector a, vector b, int N, double abs=0.1, double rel=0.1) {
		int dim = a.size;
		(double res, double err) = plainmc(f, a, b, N);
		if (err <= Max(abs, rel*Abs(res))) {
			return (res, err);
		}
		else {
			double maxerr = 0;
			vector maxa = new vector(dim);
			vector maxb = new vector(dim);
			for (int d=0; d<dim; d++) {
				vector b1 = b.copy();
				b1[d] = (b[d] - a[d])/2 + a[d];
				vector a2 = a.copy();
				a2[d] = (b[d] - a[d])/2 + a[d]; 
				(double res1, double err1) = plainmc(f, a, b1, N/10);
				(double res2, double err2) = plainmc(f, a2, b, N/10);
				if (err1 > maxerr) {
					maxerr = err1;
					maxa = a2;
					maxb = b1;
				}
				if (err2 > maxerr) {
					maxerr = err2;
					maxa = a2;
					maxb = b1;
				}
			}
			(double totres1, double toterr1) = stratmc(f, a, maxb, N, abs:abs, rel:rel);
			(double totres2, double toterr2) = stratmc(f, maxa, b, N, abs:abs, rel:rel);
			return (totres1 + totres2, Sqrt(toterr1*toterr1 + toterr2*toterr2));
		}
	}
}
