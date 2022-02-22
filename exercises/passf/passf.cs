using static System.Math;
using static System.Console;
using static table;

public static class passf{
	public static void Main(string[] args) {
		double k = 1;
		System.Func<double, double> sin = delegate(double x){return Sin(k*x);};
		WriteLine($"k = {k}: ");
		make_table(sin, 0, 2*PI, 2*PI/8);
		k = 2;
		WriteLine("\n");
		WriteLine($"k = {k}: ");
		make_table(sin, 0, 2*PI, 2*PI/8);
		k = 3;
		WriteLine("\n");
		WriteLine($"k = {k}: ");
		make_table(sin, 0, 2*PI, 2*PI/8);
	}
}
