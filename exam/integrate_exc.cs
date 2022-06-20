using System;
using static System.Double;
using static System.Math;

public static class Integrate {
	public static (double, double) integrate(Func<double, double> f, double a, double b,
		       	double acc=0.001, double eps=0.001, double f2=NaN, double f3=NaN) {
		if (IsNegativeInfinity(a)) {
			if (IsInfinity(b)) {
				f = infinf(f);
				a = -1;
				b = 1;
			}
			else {
				f = inffin(f, b);
				a = -1;
			        b = 0;
			}
		}
		else {
			if (IsInfinity(b)) {
				f = fininf(f, a);
			        a = 0;
			        b = 1;
			}
		}
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
			return (Q, err);
		}
		else {
			(double r1, double e1) = integrate(f, a, (a+b)/2, acc/Sqrt(2), eps, f1, f2);
			(double r2, double e2) = integrate(f, (a+b)/2, b, acc/Sqrt(2), eps, f3, f4);
			return (r1 + r2, Sqrt(e1*e1 + e2*e2));
		}
	}

	private static Func<double, double> infinf(Func<double, double> f) {
		return t => f(t/(1-t*t)) * (1 + t*t)/(1 - t*t)/(1 - t*t);
	}

	private static Func<double, double> inffin(Func<double, double> f, double b) {
		return t => f(b + t/(1+t)) * 1/(1+t)/(1+t);
	}

	private static Func<double, double> fininf(Func<double, double> f, double a) {
		return t => f(a + t/(1-t)) * 1/(1-t)/(1-t);
	}
}
