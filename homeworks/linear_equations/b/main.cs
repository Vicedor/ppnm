using System;
using static System.Console;
using static System.Random;

public static class main{
	public static int Main(String[] args) {
		int n = 6;
		Random random = new Random();
		matrix A = new matrix(n, n);
		
		for (int i=0; i<n; i++) {
			for(int j=0; j<n; j++) {
				A[i,j] = random.Next(1,10);
			}
		}


		QRGS qrgs = new QRGS(A);
		WriteLine("Matrix A:");
		PrintMatrix(A);
		WriteLine("\n Inverse Matrix B:");
		matrix B = qrgs.inverse();
		PrintMatrix(B);
		WriteLine("\n Check that A*B = I:");
		PrintMatrix(A*B);
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
