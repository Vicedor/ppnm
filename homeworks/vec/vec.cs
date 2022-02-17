using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z;
	
	public vec() {
		x=y=z=0;
	}
	
	public vec(double x, double y, double z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public static vec operator*(vec v, double c) {
		return new vec(c*v.x, c*v.y, c*v.z);
	}

	public static vec operator*(double c, vec v) {
		return v*c;
	}

	public static vec operator+(vec u, vec v) {
		return new vec(u.x + v.x, u.y + v.y, u.z + v.z);
	}

	public static vec operator-(vec u, vec v) {
		return new vec(u.x - v.x, u.y - v.y, u.z - v.z); 
	}

	public static vec operator-(vec v) {
		return new vec(-v.x, -v.y, -v.z);
	}

	public void print(string s) {
		Write(s);
		WriteLine($" {x} {y} {z}");
	}

	public void print() {
		this.print("");
	}

	public double dot(vec other) {
		return this.x*other.x + this.y*other.y + this.z*other.z;
	}

	public static double dot(vec v, vec w) {
		return v.dot(w);
	}

	public static vec cross(vec v, vec u) {
		return new vec(v.y*u.z - v.z*u.y, v.z*u.x - v.x*u.z, v.x*u.y - v.y*u.x);
	}
	
	public vec cross(vec other) {
		return cross(this, other);
	}

	public double norm() {
		return Sqrt(Pow(this.x, 2) + Pow(this.y, 2) + Pow(this.z, 2));
	}

	public static double norm(vec v) {
		return v.norm();
	}

	public override string ToString() {
		return $"(x, y, z) = ({this.x}, {this.y}, {this.z})";
	}

	public static bool approx(double a, double b, double tau=1e-9, double eps=1e-9) {
		if(Abs(a-b) < tau) {return true;}
		if(Abs(a-b)/(Abs(a) + Abs(b)) < eps) {return true;}
		return false;
	}

	public bool approx(vec other) {
		if(!approx(this.x, other.x)) {return false;}
		if(!approx(this.y, other.y)) {return false;}
		if(!approx(this.z, other.z)) {return false;}
		return true;
	}

	public static bool approx(vec v, vec u) {
		return v.approx(u);
	}
}
