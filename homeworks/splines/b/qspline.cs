using System;

public class Qspline {
	private double[] x, y, a, b, c;

	public Qspline(double[] x, double[] y) {
		int n = x.Length;
		this.x = new double[n];
	       	this.y = new double[n];
		this.a = new double[n];
		this.b = new double[n];
		this.c = new double[n];
		Array.Copy(x, this.x, n);
		Array.Copy(y, this.y, n);
		Array.Copy(y, this.a, n);
		for (int i=0; i < n - 1; i++) {
			this.b[i] = (y[i + 1] - y[i])/(x[i + 1] - x[i]);
		}
		double[] c1 = new double[n];
		double[] c2 = new double[n];
		c1[0] = 0;
		c2[n - 1] = 0;
		for (int i=0; i < n - 2; i++) {
			double dbi = b[i + 1] - b[i];
			double dxi = x[i + 1] - x[i];
			double dxi1 = x[i + 2] - x[i + 1];
			c1[i + 1] = (c[i]*dxi - dbi)/dxi1;
			c2[n - 1 - i] = (dbi - c[i + 1]*dxi1)/dxi;
		}
		for (int i=0; i < n; i++) {
			c[i] = (c1[i] + c2[i])/2;
		}
	}

	public double Eval(double z) {
		int i = Binsearch(0, x.Length - 1, z);
		return y[i] + b[i]*(z - x[i]) + c[i]*(z - x[i])*(z - x[i + 1]);
	}

	public double Derivative(double z) {
		int i = Binsearch(0, x.Length - 1, z);
		double a1 = b[i] - c[i]*(x[i] + x[i + 1]);
		double a2 = c[i];
		return a1 + 2*a2*z;
	}

	public double Integral(double z, double k) {
		int i = Binsearch(0, x.Length - 1, z);
		double s = 0;
		for (int j=0; j<i; j++) {
			double a0 = y[j] - b[j]*x[j] + c[j]*x[j]*x[j+1];
			double a1 = b[j] - c[j]*(x[j] + x[j+1]);
			double a2 = c[j];
			s += a0*(x[j+1] - x[j]) + a1*(x[j+1]*x[j+1] - x[j]*x[j])/2 + a2*(x[j+1]*x[j+1]*x[j+1] - x[j]*x[j]*x[j])/3;
		}
		double a0i = y[i] - b[i]*x[i] + c[i]*x[i]*x[i+1];
		double a1i = b[i] - c[i]*(x[i] + x[i+1]);
		double a2i = c[i];
		s += a0i*(z - x[i]) + a1i*(z*z - x[i]*x[i])/2 + a2i*(z*z*z - x[i]*x[i]*x[i])/3 + k;
		return s;
	}

	public double Integral(double a, double b, double k) {
		return Integral(b, k) - Integral(a, k);
	}

	public double Integral(double z) {
		return Integral(z, 0);
	}

	private int Binsearch(int i, int j, double z) {
		if (j - i <= 1){
			return i;
		}
		else {
			int mid = (i + j)/2;
			if (z > x[mid]) return Binsearch(mid, j, z); else return Binsearch(i, mid, z);
		}
	}
}
