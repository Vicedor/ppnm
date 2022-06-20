Exam Exercise 18 -- Practical Programming and Numerical Methods

Victor Rueskov Christiansen - Study Nr. 201808341

The exercise is to convert an adaptive integrator such that it can integrate complex valued functions.

I have chosen to convert the Recursive adaptive integrator from "Adaptive Integration"-homework.

a)
For part A, I converted the integrator to be able to integrate functions with complex arguments and complex values.
This was a simple matter of converting the "double" keywords to "complex"-type.
Furthermore, I added a method to do contour integration along a straight line. I used the parametrization
z(t) = a + (b - a)*t, where a and b are the complex valued end-points. Using this parametrization, the integral
becomes
int_a^b f(z)dz = int_0^1 f(z(t))*(b-a) dt.

Finally I added some examples of contour integrals. I made two examples:
	1) The straight line integral over f(z) = |z|^2 from -1 to i.
	2) The straight line integral over f(z) = exp(-x^2/(4*i*Delta^2)) / sqrt(4*pi*i*Delta^2 from -1-i to 1+i.
	   For Delta -> 0, this expression approaches the delta function along the line y=x in the complex plane.
	   To test this, I integrated from -1-i to 1+i (a line along y=x in complex plane) and tested whether the
	   integral approaches 1, as it should for the delta-function. The result is shown in the delta_pyx.png
	   plot, where it is clear that the integral approaches 1 as it should. 

b)
For part B, I added the possibility to do any contour integration in the complex plane, over any line segment C.
This is an extension to only doing straight lines in part a. The parametrization is the general expression
int_C f(z)dz = int_t1^t2 f(z(t)) z'(t) dt
so this time z(t) and z'(t) must be parameters to the integration-function. As such it is now possible to do
integration along any parametrizable line. A circular path can for instance be parametrized by z(t)=exp(it)
with t1=0 to t2=2pi.
Furthermore, I added an estimation of the error of the integration to the output.
I also included the Clenshaw-Curtis variable transformation to the integration rutine, to allow for more complex
integrals to be evaluated in fewer steps.

Finally I added some examples of contour integrals along non-linear paths. I made 4 examples
	1) The integral over f(z) = conjugate(z) along a parabola from a=-3+9i to b=12+16i,
	   using the parametrization z(t)=3t+it^2 from t1=-1 to t2=4.
	2) The integral over f(z) = 1/z along a unit circle around the origin.
	3) The integral over f(z) = |z|^2 from a=-1 to b=i, but this time along a circular path,
	   using z(t) = e^(it) from t1=pi to t2=pi/2.
	4) The integral representation of the Bessel function J_n(x) as suggested by the exercise
	   description. The integral is over f(z)=z^(-n-1)*exp(x*(z-1/z)/2), along a unit circle
	   around the origin. I used this integral representation to find the Bessel function for
	   n=0, 1, 2 and 3, and plotted them, along with some tabulated values.


All in all, I would consider parts a and b complete for a total of 9 points.
