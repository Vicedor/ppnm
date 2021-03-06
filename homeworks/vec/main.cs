using static System.Console;

static class main{
	static void Main(){
		// Exercise A:
		double c = 2.5;
		vec v = new vec(1, 2, 3);
		vec u = new vec(2, 4, 6);
		v.print("This is the v vector:");
		u.print("This is the u vector:");
		(v + u).print("This is v + u:");
		(v - u).print("This is v - u:");
		(-v).print("This is -v:");
		vec t = c*v;
		t.print($"This is {c}*v:");
		vec r = v*c;
		r.print($"This is v*{c}:");

		// Exercise B:
		WriteLine("\nThese next lines writes to Console uses the vec ToString method:");
		Write("v dot u: ");WriteLine((v.dot(u)));
		Write("v dot u using static function: ");WriteLine(vec.dot(v, u));
		Write("v cross u: ");WriteLine(v.cross(u));
		Write("v cross u using static function: ");WriteLine(vec.cross(v, u));
		Write("norm of v: ");WriteLine(v.norm());
		Write("norm of v using static function:");WriteLine(vec.norm(v));

		// Exercise C:
		WriteLine("\n These next lines are a test of the approx methods:");
		vec a = new vec(1, 1, 1);
		vec b = new vec(1, 1, 1);
		vec d = new vec(1+1e-10, 1+1e-10, 1+1e-10);
		vec e = new vec(1+1e-8, 1+1e-8, 1+1e-8);
		vec f = new vec(1-1e-10, 1-1e-10, 1-1e-10);
		vec g = new vec(1-1e-8, 1-1e-8, 1-1e-8);
		WriteLine($"{a.ToString()} = {b.ToString()}: {a.approx(b)}");
		WriteLine($"{a.ToString()} = {d.ToString()}: {a.approx(d)}");
		WriteLine($"{a.ToString()} = {e.ToString()}: {a.approx(e)}");
		WriteLine($"{a.ToString()} = {f.ToString()}: {vec.approx(a,f)}");
		WriteLine($"{a.ToString()} = {g.ToString()}: {vec.approx(a,g)}");
	}
}
