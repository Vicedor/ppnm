using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		double b = 0.25;
		double c = 5.0;
		Func<double, vector, vector> f = delegate(double t, vector y) {
		       double theta = y[0];
		       double omega = y[1];
		       return new vector(omega, -b*omega - c*Sin(theta));
		};
		double begin = 0;
		double end = 10;
		vector y0 = new vector(PI - 0.1, 0.0);
		vector yend = ode.driver(f, begin, y0, end);
		yend.print();
		return 0;
	}
}
