using System;
using static System.Console;

public static class main{
	public static void Main(String[] args) {
		Func<vector, vector> f = (x) => new vector(2*(200*x[0]*x[0]*x[0] - 200*x[0]*x[1]+x[0]-1), 200*(x[1]-x[0]*x[0]));
		vector x0 = new vector(0.1, 0.1);
		vector roots = Root.Newton(f, x0);
		WriteLine($"Root to Rosenbrock's valley function is [{roots[0]}, {roots[1]}] should be [1, 1]");
	}
}
