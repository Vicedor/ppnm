using static System.Math;

public static class Jacobi{

	public static void timesJ(matrix A, int p, int q, double theta) {
		double c = Cos(theta);
		double s = Sin(theta);
		for (int i=0; i<A.size1; i++) {
			double aip = A[i, p];
			double aiq = A[i, q];
			A[i, p] = c*aip - s*aiq;
			A[i, q] = s*aip + c*aiq;
		}
	}

	public static void Jtimes(matrix A, int p, int q, double theta) {
		double c = Cos(theta);
		double s = Sin(theta);
		for (int j=0; j<A.size1; j++) {
			double apj = A[p, j];
			double aqj = A[q, j];
			A[p, j] = c*apj + s*aqj;
			A[q, j] = -s*apj + c*aqj;
		}
	}
}
