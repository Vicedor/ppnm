using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static void Main(String[] args) {
		double correct_epsilon = -0.5;
		Func<double, double> correct_f = r => r*Exp(-r);
		vector eps0 = new vector(-10.0);
		vector res = Root.Newton(M, eps0);
		WriteLine($"Found epslion = {res[0]} compared with correct epsilon = {correct_epsilon}.");
		genlist<double> xlist = new genlist<double>();
		genlist<vector> ylist = new genlist<vector>();
		M(res, xlist:xlist, ylist:ylist);
		for(int i=0; i<xlist.size; i++) {
			Error.WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {correct_f(xlist.data[i])}");
		}
		Error.WriteLine();
		Error.WriteLine();
		TestConvergence();
	}

	public static vector M(vector epsilon, genlist<double> xlist=null, genlist<vector> ylist=null) {
		Func<double, vector, vector> f = delegate(double r, vector y) {
		       double func = y[0];
		       double dfuncdr = y[1];
		       return new vector(dfuncdr, -2*func*(epsilon[0] + 1/r));
		};
		double rmin = 0.01;
		double rmax = 8;
		vector y0 = new vector(rmin - rmin*rmin, 1 - 2*rmin);
		vector yend = ode.driver(f, rmin, y0, rmax, xlist:xlist, ylist:ylist);
		return new vector(yend[0]);
	}
}
