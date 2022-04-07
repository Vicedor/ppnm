using System;
using static System.Double;
using static System.Math;

public static class Integrate {
	public static double integrate(Func<double, double> f, double a, double b,
		       	double acc=0.001, double eps=0.001, double f2=NaN, double f3=NaN) {
		double h = b-a;
		if (IsNaN(f2)) {
			f2 = f(a + 2*h/6);
			f3 = f(a + 4*h/6);
		}
		double f1 = f(a + h/6);
		double f4 = f(a + 5*h/6);
		double Q = (2*f1 + f2 + f3 + 2*f4)/6 * (b - a);
		double q = (  f1 + f2 + f3 +   f4)/4 * (b - a);
		double err = Abs(Q - q);
		if (err <= Max(acc, Abs(Q) * eps)) {
			return Q;
		}
		else {
			return integrate(f, a, (a+b)/2, acc/Sqrt(2), eps, f1, f2) + 
			       integrate(f, (a+b)/2, b, acc/Sqrt(2), eps, f3, f4);
		}
	}

	public static double VT_integrate(Func<double, double> f, double a, double b,
			double acc=0.001, double eps=0.001, double f2=NaN, double f3=NaN) {
		Func<double, double> f_transform = (theta => f((a+b)/2 + (b - a)/2 * Cos(theta)) * Sin(theta) * (b - a)/2);
		return integrate(f_transform, 0, PI, acc:acc, eps:eps, f2:f2, f3:f3);
	}
}
