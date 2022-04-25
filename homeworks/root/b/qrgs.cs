using static System.Math;

public class QRGS{
	public matrix Q
	{get;}
	public matrix R
	{get;}

	public QRGS(matrix A) {
		matrix B = A.copy();
		Q = new matrix(B.size1, B.size2);
		R = new matrix(B.size2, B.size2);
		for (int i=0; i < B.size2; i++) {
			R[i, i] = Sqrt(B[i].dot(B[i]));
			Q[i] = B[i]/R[i,i];
			for (int j=i; j < B.size2; j++) {
				R[i,j] = Q[i].dot(B[j]);
				B[j] = B[j] - Q[i] * R[i, j];
			}
		}
	}

	public vector solve(vector b) {
		vector c = Q.T * b;
		for (int i=c.size - 1; i >= 0; i--) {
			double sum = 0;
			for (int k=i+1; k < c.size; k++) {
				sum += R[i,k]*c[k];
			}
			c[i] = (c[i] - sum)/R[i, i];
		}
		return c;
	}
}
