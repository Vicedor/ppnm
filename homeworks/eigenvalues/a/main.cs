using System;
using static System.Console;
using static System.Random;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		int n=8;
		Random random = new Random();
		matrix A = new matrix(n, n);
		for (int i=0; i<n; i++) {
			for (int j=i; j<n; j++) {
				int r = random.Next(1, 10);
				A[i,j] = r;
				A[j,i] = r;
			}
		}
		matrix V = new matrix(A.size1, A.size2);
		for (int i=0; i<V.size1; i++) {
			for (int j=0; j<V.size2; j++) {
				if (i == j) {
					V[i, j] = 1;
				}
				else {
					V[i, j] = 0;
				}
			}
		}
		matrix A_copy = A.copy();
		jacobi_diag(A, V);
		WriteLine("Original A:");
		A_copy.print();
		WriteLine("Diagonalized D:");
		A.print();
		WriteLine("Matrixproduct V.T * A * V:");
		matrix VTAV = V.T * A_copy * V;
		VTAV.print();
		WriteLine("Matrixproduct V * D * V.T:");
		matrix VDVT = V * A * V.T;
		VDVT.print();
		WriteLine("Matrixproduct V.T * V:");
		matrix VTV = V.T * V;
		VTV.print();
		WriteLine("Matrixproduct V * V.T");
		matrix VVT = V * V.T;
		VVT.print();
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

	private static void jacobi_diag(matrix A, matrix V) {
		bool changed;
		int n = A.size1;
		V.set_unity();
		do {
			changed = false;
			for (int p=0; p<n-1; p++) {
				for (int q=p+1; q<n; q++) {
					double apq = A[p, q];
					double app = A[p, p];
					double aqq = A[q, q];
					double theta = 0.5 * Atan2(2*apq, aqq-app);
					double c = Cos(theta);
					double s = Sin(theta);
					double new_app = c*c*app - 2*s*c*apq + s*s*aqq;
					double new_aqq = s*s*app + 2*s*c*apq + c*c*aqq;
					if (new_app != app || new_aqq != aqq) {
						changed = true;
						Jacobi.timesJ(A, p, q, theta);
						Jacobi.Jtimes(A, p, q, -theta);
						Jacobi.timesJ(V, p, q, theta);
					}
				}
			}
		} while(changed);
	}
}
