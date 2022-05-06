using System;
using static System.Math;
using static System.Random;

public static class MonteCarlo {
	public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N) {
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++) {
			V *= b[i] - a[i];
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

	public static (double, double) quasimc(Func<vector, double> f, vector a, vector b, int N) {
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++) {
			V *= b[i] - a[i];
		}
		double sum1 = 0;
		double sum2 = 0;
		vector x = new vector(dim);
		vector y = new vector(dim);
		Random rnd = new Random();
		for (int i=0; i<N; i++) {
			int n = rnd.Next();
			int m = rnd.Next();
			vector rn = Halton(n, dim);
			vector rm = Halton(m, dim);
			for (int j=0; j<dim; j++) {
				x[j] = a[j] + rn[j] * (b[j] - a[j]);
				y[j] = a[j] + rm[j] * (b[j] - a[j]);
			}
			sum1 += f(x);
			sum2 += f(y);
		}
		double mean = (sum1/N + sum2/N)/2;
		double sigma = Abs(sum1/N - sum2/N);
		return (mean*V, sigma*V/Sqrt(N));
	}

	private static vector Halton(int n, int d) {
		vector x = new vector(d);
		int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
		for (int i=0; i<d; i++) {
			x[i] = Corput(n, primes[i]);
		}
		return x;
	}

	private static double Corput(int n, int prime) {
		double q = 0;
		double bk = 1.0/prime;
		while (n > 0) {
			q += (n % prime) * bk;
			n /= prime;
			bk /= prime;
		}
		return q;
	}
}
