using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static double rmin = 0.01;
	public static double rmax = 8;
	public static double acc = 1e-8;
	public static double eps = 1e-8;

	public static void Main(String[] args) {
		double correct_epsilon = -0.5;
		Func<double, double> correct_f = r => r*Exp(-r);
		vector eps0 = new vector(-10.0);
		vector res = Root.Newton(M, eps0);
		WriteLine($"Found epsilon = {res[0]} compared with correct epsilon = {correct_epsilon}.");
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
		vector y0 = new vector(rmin - rmin*rmin, 1 - 2*rmin);
		vector yend = ode.driver(f, rmin, y0, rmax, xlist:xlist, ylist:ylist, acc: acc, eps: eps);
		return new vector(yend[0]);
	}

	private static void TestConvergence() {
		vector eps0 = new vector(-10.0);
		vector energy = new vector(0);
		double correct_eps = -0.5;
		using(var outfile = new StreamWriter("convergence.txt")) {
			rmin = 0.01;
			
			for (double new_rmax=0.5; new_rmax<8; new_rmax += 0.2) {
				rmax = new_rmax;
				energy = Root.Newton(M, eps0);
				outfile.WriteLine($"{rmax} {energy[0]} {correct_eps}");
			}
			outfile.WriteLine("\n");

			rmax = 8;
			for (double new_rmin=0.5; new_rmin >=0.01; new_rmin -= 0.01) {
				rmin = new_rmin;
				energy = Root.Newton(M, eps0);
				outfile.WriteLine($"{rmin} {energy[0]} {correct_eps}");
			}
			outfile.WriteLine("\n");

			rmin = 0.01;
			rmax = 8;
			
			eps = 0.01;

			for (double new_acc=0.01; new_acc >= 1e-8; new_acc -= 5e-5) {
				acc = new_acc;
				energy = Root.Newton(M, eps0);
				outfile.WriteLine($"{acc} {energy[0]} {correct_eps}");
			}

			outfile.WriteLine("\n");
			acc = 0.001;

			for (double new_eps=0.01; new_eps >= 1e-8; new_eps -= 1e-4) {
				eps = new_eps;
				energy = Root.Newton(M, eps0);
				outfile.WriteLine($"{eps} {energy[0]} {correct_eps}");
			}
		}
	}
}
