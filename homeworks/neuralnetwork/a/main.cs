using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(String[] args) {
		int n = 20;
		double a = -1.0;
		double b = 1.0;
		int m = 5;
		Func<double, double> g = (x) => Cos(5*x - 1)*Exp(-x*x);
		Func<double, double> activation = (x) => x*Exp(-x*x);
		vector t = new vector(n);
		vector y = new vector(n);
		for (int i=0; i<n; i++) {
			double ti = (b - a)*i/(n - 1) + a;
			t[i] = ti;
			y[i] = g(ti);
			WriteLine($"{t[i]} {y[i]}");
		}
		WriteLine();
		WriteLine();
		ANN ann = new ANN(m, activation, a, b);
		ann.Train(t, y);
		for (double z=a; z<= b; z+=1.0/32) {
			WriteLine($"{z} {ann.Response(z)}");
		}
	}
}
