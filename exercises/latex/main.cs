using static System.Console;
using static System.Math;

public static class main{
	static double ex(double x){
		if (x<0) {
			return 1/ex(-x);
		}
		if (x>1.0/8) {
			return Pow(ex(x/2), 2);
		}
		return 1+x*(1+x/2*(1+x/3*(1+x/4*(1+x/5*(1+x/6*(1+x/7*(1+x/8*(1+x/9*(1+x/10)))))))));
	}

	public static void Main(string[] args) {
		double dx = 1.0/64;
		double shift = dx/2;
		for (double x=-5+shift; x <= 5; x+=dx) {
			WriteLine($"{x} {ex(x)}");
		}
	}
}
