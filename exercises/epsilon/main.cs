using static System.Console;
using static System.Math;

static class epsilon{
	static void Main(){
		Write("Exercise 1:\n");
		int i=1;
		while(i+1>i) {i++;}
		Write($"My max int = {i}\n");
		Write($"int.MaxValue = {int.MaxValue}\n");
		int j=1;
		while(j-1<j) {j--;}
		Write($"My min int = {j}\n");
		Write($"int.MinValue = {int.MinValue}\n");

		Write("Exercise 2:\n");
		double x=1;
		while(1+x!=1){x/=2;}
		x*=2;
		Write($"The machine epsilon for double = {x}\n");
		Write($"The machine epsilon for double should be 2^(-52) = {Pow(2, -52)}\n");
		float y=1F;
		while((float) (1F+y) != 1F) {y/=2F;}
		y*=2F;
		Write($"The machine epsilon for float = {y}\n");
		Write($"The machine epsilon for float should be 2^{-23} = {Pow(2, -23)}\n");

		Write("Exercise 3:\n");
		int n= (int) 1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;
		sumA+=1;
		for(int k=0; k<n; k++) {sumA+=tiny;}
		Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e}\n");
		for(int l=0; l<n;l++) {sumB+=tiny;}
		sumB+=1;
		Write($"sumB-1 = {sumB-1:e} should be {n*tiny:e}\n");
		
		Write($"The difference comes from the fact that c-sharp disregards adding machine epsilon to 1 as negligeble, so in sumA it is disregarded each time, but in sumB when 1 is added in the end it is not disregarded. So only in sumB does the epsilons add up because they are added before 1 is added.\n");

		Write("Exercise 4:\n");
		double a = 2e-9;
		double b = 1.5e-9;
		Write($"a = {1}, b = {0} and |a-b|>1e-9 should be False and it is {approx(1,0)}\n");
		Write($"a = {a}, b = {b} and |a-b|<1e-9 should be True and it is {approx(a,b)}\n");
		Write($"a = {1}, b = {1} and |a-b|<1e-9 should be True and it is {approx(1,1)}\n");
		Write($"a = {1e10}, b = {1e10-1} and |a-b|/|a+b|<1e-9 should be True and it is {approx(1e10,1e10-1)}\n");
	}

	private static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9) {
		if (Abs(a - b) < tau) {return true;}
		if (Abs(a - b) / (Abs(a) + Abs(b)) < epsilon) {return true;}
		else {return false;}
	}
}
