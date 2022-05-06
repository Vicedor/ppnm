using System;
using static System.Math;
using static System.Console;

public class ANN {
	private int n;
	private Func<double, double> f;
	private vector p;

	public ANN(int n, Func<double, double> f, double start, double end) {
		this.n = n;
		this.f = f;
		this.p = new vector(3*n);
		for (int i=0; i<3*n; i++) {
			if (i < n) {
				this.p[i] = (end - start)*i/(n - 1) + start;
			}
			else {
				this.p[i] = 1;
			}
		}
	}

	public double Response(double x) {
		double sum = 0;
		for (int i=0; i<n; i++) {
			double ai = this.p[i + 0*n];
			double bi = this.p[i + 1*n];
			double wi = this.p[i + 2*n];
			sum += f((x - ai)/bi) * wi;
		}
		return sum;
	}

	public void Train(vector x, vector y) {
		Func<vector, double> Cost = q => {
			this.p = q;
			double sum = 0;
			for (int k=0; k<x.size; k++) {
				sum += Pow(Response(x[k]) - y[k], 2);
			}
			return sum/x.size;
		};
		
		(vector opt, double iters) = Minimization.QNewton(Cost, this.p);
		this.p = opt;
	}
}
