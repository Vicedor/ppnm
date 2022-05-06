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
			}
			double fx = f(x);
			sum1 += fx;
			sum2 += fx*fx;
		}
		double mean = sum1/N;
		double sigma = Sqrt(sum2/N - mean*mean);
		return (mean*V, sigma*V/Sqrt(N));
	}
}
