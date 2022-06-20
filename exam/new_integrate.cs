using System;
using static System.Math;
using static System.Console;
using static System.Double;
using static cmath;
using static complex;

public class integrator{
	public static complex integrate(Func<complex, complex> f, complex a, complex b,complex f2, complex f3, double delta=0.001, double eps=0.001){
			complex h=b-a;
				complex f1=f(a+h/6);
					complex f4=f(a+5.0*h/6);
						complex Q= (2*f1+f2+f3+2*f4)/6*(b-a);
							complex q= (f1+f2+f3+f4)/4*(b-a);
								double err=magnitude(Q-q);
									if (err<= delta+eps*magnitude(Q)){return Q;}
										else{
												return integrate(f,a,(a+b)/2,f1,f2,delta/Sqrt(2),eps)+integrate(f,(a+b)/2,b,f3,f4,delta/Sqrt(2),eps);}

	}//Integrate

	public static complex adapter(Func<complex, complex> f, complex a, complex b, double delta=0.001, double eps=0.001){
			complex h=b-a;
				complex f2=f(a+2*h/6);
					complex f3=f(a+4*h/6);
						return integrate(f,a,b,f2,f3);
	}

	public static complex vt_integrate(Func<complex, complex> f, complex a, complex b, double delta=0.001, double eps=0.001){
			Func<complex,complex> f_vt=x=>f((a+b)/2+(b-a)/2*cos(x))*sin(x)*(b-a)/2;
				return adapter(f_vt,0,PI);
					}





}//integrator

