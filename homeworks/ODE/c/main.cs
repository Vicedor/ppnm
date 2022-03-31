using System;
using static System.Console;
using System.IO;
using static System.Math;

public static class main{
	public static int Main(String[] args) {
		Func<double, vector, vector> f = delegate(double t, vector y) {
		       double r1x = y[0];
		       double r1y = y[1];
		       vector r1 = new vector(r1x, r1y);
		       double v1x = y[2];
		       double v1y = y[3];
		       vector v1 = new vector(v1x, v1y);

		       double r2x = y[4];
		       double r2y = y[5];
		       vector r2 = new vector(r2x, r2y);
		       double v2x = y[6];
		       double v2y = y[7];
		       vector v2 = new vector(v2x, v2y);

		       double r3x = y[8];
		       double r3y = y[9];
		       vector r3 = new vector(r3x, r3y);
		       double v3x = y[10];
		       double v3y = y[11];
		       vector v3 = new vector(v3x, v3y);
			

		       vector dv1dt = -(r1 - r2)/Pow((r1 - r2).norm(), 3) - (r1 - r3)/Pow((r1 - r3).norm(), 3);
		       vector dv2dt = -(r2 - r3)/Pow((r2 - r3).norm(), 3) - (r2 - r1)/Pow((r2 - r1).norm(), 3);
		       vector dv3dt = -(r3 - r1)/Pow((r3 - r1).norm(), 3) - (r3 - r2)/Pow((r3 - r2).norm(), 3);
		       double[] arr = {v1[0], v1[1], dv1dt[0], dv1dt[1], 
			       	       v2[0], v2[1], dv2dt[0], dv2dt[1],
				       v3[0], v3[1], dv3dt[0], dv3dt[1]};
		       return new vector(arr);
		};
		double begin = 0;
		double end = 10;

		double r1x0 = -0.97000436;
		double r1y0 = 0.24308753;
		double v1x0 = 0.4662036850;
		double v1y0 = 0.4323657300;
		
		double r2x0 = 0;
		double r2y0 = 0;
		double v2x0 = -0.93240737;
		double v2y0 = -0.86473146;

		double r3x0 = - r1x0;
		double r3y0 = - r1y0;
		double v3x0 = v1x0;
		double v3y0 = v1y0;
		
		double[] arr0 = {r1x0, r1y0, v1x0, v1y0,
				r2x0, r2y0, v2x0, v2y0,
				r3x0, r3y0, v3x0, v3y0};
		vector y0 = new vector(arr0);
		genlist<double> xlist = new genlist<double>();
		genlist<vector> ylist = new genlist<vector>();
		vector yend = ode.driver(f, begin, y0, end, xlist, ylist);
		for (int i=0; i<xlist.size; i++) {
			Write($"{xlist.data[i]} ");
			for (int j=0; j<ylist.data[0].size; j++) {
				Write($"{ylist.data[i][j]} ");
			}
			Write("\n");
		}
		return 0;
	}
}
