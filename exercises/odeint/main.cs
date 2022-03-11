using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public static class main{
	public static void Main(string[] args) {
		double b = 0.25;
		double c = 5.0;
		Func<double, vector, vector> F = delegate(double t, vector y) {
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega - c*Sin(theta));
		};
		double begin = 0;
		double end = 10;
		vector y0 = new vector(PI - 0.1, 0.0);
		List<double> xlist = new List<double>();
		List<vector> ylist = new List<vector>();
		ode.ivp(F, begin, y0, end, xlist, ylist);
		for (int i=0; i < xlist.Count; i++) {
			WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
		}
	}
}
