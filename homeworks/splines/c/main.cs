using static System.Console;
using System.IO;

public static class main{
	public static int Main(string[] args) {
		string infile = null;
		string outfile = null;

		double[] x, y;
		if (args.Length == 0) {
			Error.Write("There was no input argument! \n");
			return 1;
		}
		else {
			foreach(string arg in args) {
				string[] words = arg.Split(':');
				if (words[0] == "-input") {
					infile = words[1];
				}
			}
		}
		int n = TotalLines(infile);
		x = new double[n];
		y = new double[n];
		StreamReader instream = new StreamReader(infile);
		int i = 0;
		for (string line = instream.ReadLine(); line!=null; line = instream.ReadLine()) {
			string[] numbers = line.Split(' ');
			x[i] = double.Parse(numbers[0]);
			y[i] = double.Parse(numbers[1]);
			i++;
		}


		Cspline cspline = new Cspline(x, y);

		double dz = 1.0/64;
		for (double z=0; z <= 5; z+=dz) {
			WriteLine($"{z} {cspline.Eval(z)} {cspline.Derivative(z)} {cspline.Integrate(z)}");
		}
		return 0;
	}

	public static int TotalLines(string filePath) {
		StreamReader r = new StreamReader(filePath);
		int i = 0;
		while (r.ReadLine() != null) { i++; }
		return i;
	}
		
}
