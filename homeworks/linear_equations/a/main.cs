using System;
using static System.Console;
using System.IO;

public static class main{
	public static int Main(String[] args) {
		string matrixfile = null;
		string vectorfile = null;
		if (args.Length == 0) {
			Error.Write("There was no input argument! \n");
			return 1;
		}
		else {
			foreach(string arg in args) {
				string[] words = arg.Split(':');
				if (words[0] == "-inputmatrix") {
					matrixfile = words[1];
				}
				if (words[0] == "-inputvector") {
					vectorfile = words[1];
				}
			}
		}
		StreamReader matrixstream = new StreamReader(matrixfile);
		String m = matrixstream.ReadToEnd();
		StreamReader vectorstream = new StreamReader(vectorfile);
		String v = vectorstream.ReadToEnd();


		matrix A = new matrix(m);
		vector b = new vector(v);
		QRGS qrgs = new QRGS(A);
		WriteLine("Matrix A:");
		PrintMatrix(A);
		WriteLine("\n Matrix Q:");
		PrintMatrix(qrgs.Q);
		WriteLine("\n Matrix R:");
		PrintMatrix(qrgs.R);
		WriteLine("\n Matrix Q.T*Q:");
		PrintMatrix(qrgs.Q.T * qrgs.Q);
		WriteLine("\n Matrix Q*R:");
		PrintMatrix(qrgs.Q * qrgs.R);
		WriteLine("\n Vector b is:");
		b.print();
		WriteLine("\n Solution to Ax=b is x:");
		vector x = qrgs.solve(b);
		x.print();
		WriteLine("\n Check that A*x = b:");
		vector c = A*x;
		c.print();
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
}
