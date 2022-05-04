using System;
using static System.Console;
using static System.Math;

public static class Minimization {
	private static double eps = Pow(2, -26);

	private static vector gradient(Func<vector, double> f, vector x) {
		vector dfdx = new vector(x.size);
		double fx = f(x);
		for(int i=0; i<x.size; i++) {
			double dx = Abs(x[i]) * eps;
			if (Abs(x[i]) < eps) {
				dx = eps;
			}
			x[i] += dx;
			dfdx[i] = (f(x) - fx)/dx;
			x[i] -= dx;
		}
		return dfdx;
	}

	public static (vector, double) QNewton(Func<vector, double> f, vector xstart, double acc=1e-3) {
		vector x = xstart;
		vector dfdx = gradient(f, x);
		matrix B = matrix.id(x.size);
		vector deltax = -B*dfdx;
		double alpha = 1e-4;
		int maxiter = 10000;
		int i = 0;
		while (dfdx.norm() > acc && deltax.norm() > eps*x.norm() && i < maxiter) {
			i++;
			double lambda = 1;
			deltax = - B*dfdx;
			vector s = lambda*deltax;
			while (f(x + s) >= f(x) + alpha * s.dot(dfdx)) {
				lambda = lambda/2;
				s = lambda*deltax;
				if (lambda < eps) {
					B = matrix.id(x.size);
					break;
				}
			}
			vector dfdxs = gradient(f, x + s);
			vector y = dfdxs - dfdx;
			vector u = s - B*y;
			double uty = u.dot(y);
			if (Abs(uty) > 1e-6) {
				B = B + matrix.outer(u, u)/uty;
			}
			else {
				B = matrix.id(x.size);
			}
			x = x + s;
			dfdx = dfdxs;
		}
		return (x, i);
	}
}
