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

	public matrix inverse() {
		matrix inv = new matrix(Q.size1, Q.size2);
		for (int i=0; i<inv.size2; i++) {
			vector ei = unitvector(i, inv.size2);
			vector xi = solve(ei);
			inv[i] = xi.data;
		}
		return inv;
	}

	private vector unitvector(int i, int n) {
		double[] data = new double[n];
		for (int j=0; j<n; j++) {
			if (i == j) {
				data[j] = 1;
			}
			else {
				data[j] = 0;
			}
		}
		return new vector(data);
	}
}
