using System;
using static System.Console;
using static cmath;
using static complex;
using static System.Math;

public static class main{
	static complex G(complex z){
		if(abs(z) < 0) {
			return PI/sin(PI*z)/G(1 - z);
		}
		if(abs(z) < 9) {
			return G(z+1)/z;
		}
		complex lngamma = z * log(z + 1/(12*z - 1/z/10)) - z + log(2*PI/z)/2;
		return exp(lngamma);
	}

	public static void Main(string[] args) {
		double dx = 1.0/64;
		double shift = dx/2;
		for (double x=-5+shift; x <= 5; x+=dx) {
			for (double y=-5+shift; y <= 5; y+=dx){
				complex z = new complex(x, y);
				WriteLine($"{x} {y} {abs(G(z))}");
			}
		}
	}
}
