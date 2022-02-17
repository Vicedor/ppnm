using static System.Console;
using static System.Math;

static class main{
	static void Main() {
		WriteLine($"sqrt of -1.0 using cmath's sqrt function: {cmath.sqrt(-1.0)}");
		WriteLine($"sqrt of -1 using cmath's I field: {cmath.I}");
		WriteLine($"sqrt of i using cmath's sqrt function and I field: {cmath.sqrt(cmath.I)}");
		WriteLine($"e to the i using cmath's exp function and I field: {cmath.exp(cmath.I)}");
		WriteLine($"e to the i*pi using cmath's exp function and I field: {cmath.exp(cmath.I * PI)}");
		WriteLine($"i to the i using cmath's pow function and I field: {cmath.pow(cmath.I, cmath.I)}");
		WriteLine($"ln of i using cmath's log function and I field: {cmath.log(cmath.I)}");
		WriteLine($"sin(i*pi) using cmath's sin function and I field: {cmath.sin(cmath.I * PI)}");
	}
}
