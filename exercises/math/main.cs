using static System.Math;
using static System.Console;

static public class math {
	static void Main() {
		double sqrt2 = Sqrt(2.0);
		double epi = Pow(E, PI);
		double pie = Pow(PI, E);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal to 2)\n");
		Write($"e^pi = {epi}\n");
		WriteLine($"pi^e = {pie}\n");
	}

}
