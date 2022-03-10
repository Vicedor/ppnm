public class Lspline {
	private double[] x, y;

	public Lspline(double[] x, double[] y) {
		this.x = x;
		this.y = y;
	}

	public double Linterp(double z) {
		int i = Binsearch(0, x.Length - 1, z);
		double p = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
		return y[i] + p*(z - x[i]);
	}

	public double LinterpInteg(double z, double c) {
		int i = Binsearch(0, x.Length - 1, z);
		double s = 0;
		for (int j=0; j < i; j++) {
			double pj = (y[j + 1] - y[j]) / (x[j + 1] - x[j]);
			s += y[j]*(x[j+1] - x[j]) + pj*(x[j+1] - x[j])*(x[j+1] - x[j]) / 2;
		}
		double pi = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
		s += y[i]*(z - x[i]) + pi*(z - x[i])*(z - x[i]) / 2 + c;
		return s;
	}

	public double LinterpInteg(double a, double b, double c) {
		return LinterpInteg(b, c) - LinterpInteg(a, c);
	}

	private int Binsearch(int i, int j, double z) {
		if (j - i <= 1){
			return i;
		}
		else {
			int mid = (i + j)/2;
			if (z > x[mid]) return Binsearch(mid, j, z); else return Binsearch(i, mid, z);
		}
	}
}
