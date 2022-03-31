using System;
using static System.Math;

public class ode{
	public static (vector, vector) step45(Func<double, vector, vector> f, double x, vector y, double h) {
		double c2 = 1.0/4;
		double c3 = 3.0/8;
		double c4 = 12.0/13;
		double c5 = 1.0;
		double c6 = 1.0/2;

		double a21 = 1.0/4;
		double a31 = 3.0/32;
		double a41 = 1932.0/2197;
		double a51 = 439.0/216;
		double a61 = -8.0/27;
		double a32 = 9.0/32;
		double a42 = -7200.0/2197;
		double a52 = -8;
		double a62 = 2;
		double a43 = 7296.0/2197;
		double a53 = 3680.0/513;
		double a63 = -3544.0/2565;
		double a54 = -845.0/4104;
		double a64 = 1859.0/4104;
		double a65 = -11.0/40;

		double b1 = 16.0/135;
		double b2 = 0;
		double b3 = 6656.0/12825;
		double b4 = 28561.0/56430;
		double b5 = -9.0/50;
		double b6 = 2.0/55;
	
		double b1s = 25.0/216;
		double b2s = 0;
		double b3s = 1408.0/2565;
		double b4s = 2197.0/4104;
		double b5s = -1.0/5;
		double b6s = 0;

		vector k1 = h*f(x, y);
		vector k2 = h*f(x + c2*h, y + a21*k1);
		vector k3 = h*f(x + c3*h, y + a31*k1 + a32*k2);
		vector k4 = h*f(x + c4*h, y + a41*k1 + a42*k2 + a43*k3);
		vector k5 = h*f(x + c5*h, y + a51*k1 + a52*k2 + a53*k3 + a54*k4);
		vector k6 = h*f(x + c6*h, y + a61*k1 + a62*k2 + a63*k3 + a64*k4 + a65*k5);
		vector yh = y + b1*k1 + b2*k2 + b3*k3 + b4*k4 + b5*k5 + b6*k6;
		vector yhs = y + b1s*k1 + b2s*k2 + b3s*k3 + b4s*k4 + b5s*k5 + b6s*k6;
		vector er = yh - yhs;
		return (yh, er);
	}

	public static vector driver(Func<double, vector, vector> f,
		       	double a,
		       	vector ya,
		       	double b,
			genlist<double> xlist=null,
			genlist<vector> ylist=null,
			double h = 0.01,
			double acc=1e-8,
			double eps=1e-8
			) {
		double power = 0.25;
		double safety = 0.95;
		if (a > b) {
			throw new Exception("driver: a>b");
		}
		double x = a;
		vector y = ya;
		if (xlist != null && ylist != null) {
			xlist.push(x);
			ylist.push(y);
		}
		int i = 0;
		int max_iter = 1000000;
		while (true && i < max_iter) {
			i++;
			if (x >= b) {
				return y;
			}
			if (x + h > b) {
				h = b - x;
			}
			var (yh, eh) = step45(f, x, y, h);
			vector tol = new vector(eh.size);
			bool ok = true;
			for (int j=0; j<eh.size; j++) {
				tol[j] = Max(acc, yh[j]*eps) * Sqrt(h/(b-a));
				ok = ok && eh[j] < tol[j];
			}
			if (ok) {
				x += h;
				y = yh;
				if (xlist != null && ylist != null) {
					xlist.push(x);
					ylist.push(y);
				}
			}
			double factor = tol[0]/Abs(eh[0]);
			for (int j=0; j<eh.size; j++) {
				factor = Min(factor, tol[j]/Abs(eh[j]));
			}
			h *= Min(Pow(factor, power)*safety, 2);
			if (i == max_iter -1) {
				eh.print();
			}
		}
		System.Console.WriteLine($"x = {x}");
		return null;
	}
}
