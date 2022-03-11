using System;
using static System.Console;
using static System.Math;

public static class main{
	static double gamma(double x){
		///single precision gamma function (Gergo Nemes, from Wikipedia)
		if(x < 0) {
			return PI/Sin(PI*x)/gamma(1 - x);
		}
		if(x < 9) {
			return gamma(x+1)/x;
		}
		double lngamma = x * Log(x + 1/(12*x - 1/x/10)) - x + Log(2*PI/x)/2;
		return Exp(lngamma);
	}

	static double lngamma(double x) {
		if(x < 0) {
			return Double.NaN;
		}
		if(x < 9) {
			return lngamma(x + 1) - Log(x);
		}
		double loggamma = x * Log(x + 1/(12*x - 1/x/10)) - x + Log(2*PI/x)/2;
		return loggamma;
	}

	public static void Main(string[] args) {
		double dx = 1.0/64;
		double shift = dx/2;
		for (double x=-5+shift; x <= 5; x+=dx) {
			WriteLine($"{x} {gamma(x)}");
		}
		WriteLine("\n\n");

		for (double x=0+shift; x <= 5; x+=dx) {
			WriteLine($"{x} {lngamma(x)}");
		}
	}
}
