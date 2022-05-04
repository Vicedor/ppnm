using System;
using static System.Console;

public static class main{
	private static genlist<double> Es = new genlist<double>();
	private static genlist<double> sigmas = new genlist<double>();
	private static genlist<double> errors = new genlist<double>();

	public static void Main(String[] args) {
		string infile = null;
		foreach(string arg in args){
			string[] words = arg.Split(':');
			if(words[0] == "-input") {
				infile = words[1];
			}
		}
		var instream = new System.IO.StreamReader(infile);
		instream.ReadLine(); // Skip the first line containing the description
		for(string line=instream.ReadLine(); line != null; line = instream.ReadLine()) {
			string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			Es.push(double.Parse(numbers[0]));
			sigmas.push(double.Parse(numbers[1]));
			errors.push(double.Parse(numbers[2]));
		}
		vector x0 = new vector(120, 3, 6);
		(vector res, double iter) = Minimization.QNewton(D, x0);
		WriteLine($"Minimum found at m={res[0]}, Gamma={res[1]}, A={res[2]} with {iter} iterations");

		for (double E=100; E<=160; E+=1.0/32) {
			Error.WriteLine($"{E} {F(E, res[0], res[1], res[2])}");
		}
	}

	private static double F(double E, double m, double Gamma, double A) {
		return A/((E - m)*(E - m) + Gamma*Gamma/4);
	}

	private static double D(vector x) {
		double m = x[0];
		double Gamma = x[1];
		double A = x[2];
		double res = 0;
		for(int i=0; i<Es.data.Length; i++) {
			if (Es.data[i] != 0) {
				double Fi = F(Es.data[i], m, Gamma, A);
				res += (Fi - sigmas.data[i])*(Fi - sigmas.data[i])/errors.data[i]/errors.data[i];
			}
		}
		return res;
	}
}
