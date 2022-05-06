using System;
using static System.Math;
using static System.Console;

public class ANN {
	private int n;
	private Func<double, double> f;
	private Func<double, double> f_diff;
	private Func<double, double> f_int;
	private vector p;

	public ANN(int n, Func<double, double> f, Func<double, double> f_diff, Func<double, double> f_int, double start, double end) {
		this.n = n;
		this.f = f;
		this.f_diff = f_diff;
		this.f_int = f_int;
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
	
	private double Fp(double x, vector q, Func<double, double> func) {
		double sum = 0;
		for (int i=0; i<n; i++) {
			double ai = q[i + 0*n];
			double bi = q[i + 1*n];
			double wi = q[i + 2*n];
			sum += func((x - ai)/bi) * wi;
		}
		return sum;
	}

	public double Response(double x) {
		return Fp(x, this.p, this.f);
	}

	public double Response_diff(double x) {
		return Fp(x, this.p, this.f_diff);
	}

	public double Response_int(double x) {
		return Fp(x, this.p, this.f_int);
	}

	public void Train(vector x, vector y) {
		Func<vector, double> Cost = q => {
			double sum = 0;
			for (int k=0; k<x.size; k++) {
				sum += Pow(Fp(x[k], q, this.f) - y[k], 2);
			}
			return sum/x.size;
		};
		
		(vector opt, double iters) = Minimization.QNewton(Cost, this.p);
		this.p = opt;
	}
}
