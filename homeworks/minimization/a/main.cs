using System;
using static System.Console;

public static class main{
	public static void Main(String[] args) {
		Func<vector, double> rosenbrock = (x) => (1 - x[0])*(1-x[0]) + 100*(x[1] - x[0]*x[0])*(x[1] - x[0]*x[0]);
		vector x0_rosenbrock = new vector(0.9, 0.9);
		(vector min_rosenbrock, double iter_rosenbrock) = Minimization.QNewton(rosenbrock, x0_rosenbrock);
		WriteLine($"Minimum to Rosenbrock's valley function is [{min_rosenbrock[0]}, {min_rosenbrock[1]}] should be [1, 1]. Iterations: {iter_rosenbrock}");

		Func<vector, double> himmelblau = (x) => (x[0]*x[0] + x[1] - 11)*(x[0]*x[0] + x[1] - 11) + (x[0] + x[1]*x[1] - 7)*(x[0] + x[1]*x[1] - 7);
		vector x0_himmelblau = new vector(1, 1);
		(vector min_himmelblau, double iter_himmelblau) = Minimization.QNewton(himmelblau, x0_himmelblau);
		WriteLine($"Minimum to Himmelblau's function is [{min_himmelblau[0]}, {min_himmelblau[1]}] should be either [3, 2], [-2.8, 3.1], [-3.8, -3.3], [3.6, -1.8]. Iterations: {iter_himmelblau}");
	}
}
