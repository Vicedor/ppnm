using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		string file = null;
		if (args.Length == 0) {
			Error.Write("There was no input argument! \n");
			return 1;
		}
		else {
			foreach(string arg in args) {
				string[] words = arg.Split(':');
				if (words[0] == "-input") {
					file = words[1];
				}
			}
		}
		StreamReader stream = new StreamReader(file);
		String m = stream.ReadToEnd();
		matrix input = new matrix(m);
		vector x = input[0];
		vector y = input[1];
		vector dy = input[2];
		Func<double, double>[] fs = new Func<double, double>[] {z => 1, z => z};
		vector lny = new vector(y.size);
		vector lndy = new vector(y.size);
		for (int i=0; i < y.size; i++) {
			lny[i] = Log(y[i]);
			lndy[i] = dy[i]/y[i];
		}


		vector[] res = LeastSquares(x, lny, lndy, fs);
		vector c = res[0];
		vector dc = res[1];
		for (int i=0; i < x.size; i++) {
			double s = 0.0;
			for (int k=0; k < fs.Length; k++) {
				s += c[k] * fs[k](x[i]);
			}
			WriteLine($"{x[i]} {y[i]} {dy[i]} {Exp(s)}");
		}
		Error.WriteLine($"Coefficients for exponential fit is f(t) = {Exp(c[0])}*exp({c[1]} * t)");
		Error.WriteLine($"The uncertainties are da = {Exp(dc[0])} and dlambda = {dc[1]}");
		Error.WriteLine($"This gives a half-life of {-Log(2)/c[1]} pm {-Log(2)/(c[1] + dc[1]) + Log(2)/c[1]} days");
		Error.WriteLine($"Compare this to the current estimate of the half-life of Ra-224:");
		Error.WriteLine($"3.632 days (according to Wolfram Alpha)");
		Error.WriteLine("So within the error, the experiment does not agree with the modern value.");
		return 0;
	}

	public static void PrintMatrix(matrix A) {
		for (int i=0; i<A.size1; i++) {
			for (int j=0; j<A.size2; j++) {
				Write("{0,10:g3}", A[i,j]);
			}
			Write("\n");
		}
	}

	public static vector[] LeastSquares(vector x, vector y, vector dy, Func<double, double>[] fs) {
		int n = x.size;
		int m = fs.Length;
		matrix A = new matrix(n, m);
		vector b = new double[n];
		for (int i=0; i < n; i++) {
			for (int k=0; k < m; k++) {
				A[i, k] = fs[k](x[i])/dy[i];
			}
			b[i] = y[i]/dy[i];
		}

		QRGS qrgs = new QRGS(A);
		vector c = qrgs.solve(b);
		matrix invR = (new QRGS(qrgs.R)).inverse();
		matrix cov = invR * invR.T;
		vector dc = new vector(m);
		for (int k=0; k < m; k++) {
			dc[k] = Sqrt(cov[k,k]);
		}
		return new vector[] {c, dc};
	}
}
