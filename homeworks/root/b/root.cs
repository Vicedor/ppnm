using System;
using static System.Math;
using static System.Console;

public static class Root{
	public static vector Newton(Func<vector, genlist<double>, genlist<vector>, vector> f, vector x0, double eps=1e-2) {
		int n = x0.size;
		vector x = x0.copy();
		double stepsize = 1e8;
		double dx = Abs(x[0]) * Pow(2, -26);
		while (f(x, null, null).norm() > eps && stepsize > dx) {
			matrix J = new matrix(n, n);
			for(int k=0; k<n; k++) {
				vector newx = x.copy();
				dx = Abs(x[k]) * Pow(2, -26);
				newx[k] += dx;
				vector fresult = (f(newx, null, null) - f(x, null, null))/dx;
				for (int i=0; i<n; i++) {
					J[i,k] = fresult[i];
				}
			}
			QRGS qrgs = new QRGS(J);
			vector deltax = qrgs.solve(-f(x, null, null));
			double lambda = 1;
			while (f(x + lambda*deltax, null, null).norm() > (1 - lambda/2)*f(x, null, null).norm() && lambda > 1/32) {
				lambda /= 2;
			}
			x = x + lambda*deltax;
			stepsize = lambda*deltax.norm();
		}
		return x;
	}
}
