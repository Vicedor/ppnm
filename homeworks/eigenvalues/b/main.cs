using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		double rmax = 30;
		double dr = 0.2;
		int npoints = (int) (rmax/dr) - 1;
		vector r = new vector(npoints);
		for (int i=0; i<npoints; i++) {
			r[i] = dr*(i + 1);
		}
		matrix H = new matrix(npoints, npoints);
		for (int i=0; i<npoints-1; i++) {
			H[i,i] = -2;
			H[i, i + 1] = 1;
			H[i + 1, i] = 1;
		}
		H[npoints - 1, npoints - 1] = -2;
		H *= -0.5/dr/dr;
		for (int i=0; i<npoints; i++) {
			H[i,i] -= 1/r[i];
		}

		matrix V = matrix.id(H.size1);
		matrix D = H.copy();
		jacobi_diag(D, V);
		for (int i=0; i<V.size1; i++) {
			WriteLine($"{r[i]} {V[0][i]/Sqrt(dr)} {-V[1][i]/Sqrt(dr)} {V[2][i]/Sqrt(dr)}");
		}
		WriteLine("\n");

		for (double z=0; z<rmax; z+=1.0/16) {
			double r1 = z*2*Exp(-z);
			double r2 = z/Sqrt(2) * (1 - z/2) * Exp(-z/2);
			double r3 = z*2.0/(3*Sqrt(3)) * (1 - 2.0/3*z + 2.0/27*z*z) * Exp(-z/3);
			WriteLine($"{z} {r1} {r2} {r3}");
		}

		// Checking rmax convergence
		for (double rmax1=1.0; rmax1<=rmax; rmax1+=1/8.0) {
			npoints = (int) (rmax1/dr) - 1;
			r = new vector(npoints);
			for (int i=0; i<npoints; i++) {
				r[i] = dr*(i + 1);
			}
			H = new matrix(npoints, npoints);
			for (int i=0; i<npoints-1; i++) {
				H[i,i] = -2;
				H[i, i + 1] = 1;
				H[i + 1, i] = 1;
			}
			H[npoints - 1, npoints - 1] = -2;
			H *= -0.5/dr/dr;
			for (int i=0; i<npoints; i++) {
				H[i,i] -= 1/r[i];
			}

			V = matrix.id(H.size1);
			D = H.copy();
			jacobi_diag(D, V);
			Error.WriteLine($"{rmax1} {D[0, 0]} {D[1, 1]} {D[2, 2]}");
		}
		Error.WriteLine();
		Error.WriteLine();

		// Checking dr convergence
		for (double dr1=0.1; dr1<2; dr1+=0.1) {
			npoints = (int) (rmax/dr1) - 1;
			r = new vector(npoints);
			for (int i=0; i<npoints; i++) {
				r[i] = dr*(i + 1);
			}
			H = new matrix(npoints, npoints);
			for (int i=0; i<npoints-1; i++) {
				H[i,i] = -2;
				H[i, i + 1] = 1;
				H[i + 1, i] = 1;
			}
			H[npoints - 1, npoints - 1] = -2;
			H *= -0.5/dr/dr;
			for (int i=0; i<npoints; i++) {
				H[i,i] -= 1/r[i];
			}

			V = matrix.id(H.size1);
			D = H.copy();
			jacobi_diag(D, V);
			Error.WriteLine($"{dr1} {D[0, 0]} {D[1, 1]} {D[2, 2]}");
		}
		return 0;
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
