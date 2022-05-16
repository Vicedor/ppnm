using System;
using static System.Console;
using static System.Random;

public static class main{
	public static int Main(String[] args) {
		Random random = new Random();
		int n = 8;
		int m = 6;

		matrix A = new matrix(n, m);
		
		for(int i=0; i<n; i++) {
			for(int j=0; j<m; j++) {
				A[i,j] = random.Next(1, 10);
			}
		}

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


		WriteLine($"Checking the linear equation solver works:");
		int n2 = 5;
		matrix B = new matrix(n2, n2);
		vector b = new vector(n2);
		
		for (int i=0; i<n2; i++) {
			for (int j=0; j<n2; j++) {
				B[i,j] = random.Next(1, 10);
			}
			b[i] = random.Next(1, 10);
		}
		
		QRGS qrgs2 = new QRGS(B);

		WriteLine("\n Matrix A is:");
		PrintMatrix(B);
		WriteLine("\n Vector b is:");
		b.print();
		WriteLine("\n Solution to Ax=b is x:");
		vector x = qrgs2.solve(b);
		x.print();
		WriteLine("\n Check that A*x = b:");
		vector c = B*x;
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
