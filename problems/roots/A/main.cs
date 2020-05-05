using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    static void Main() {
	Func<vector, vector> f = x => x;
	vector startx = new vector(0.1);
	vector x0 = root.newton(f, startx);
	x0.print("x: root =", "{0,10:f10}");

	f = x => x.dot(x) * x;
	startx = new vector(0.5, 0.3, 0.4);
	x0 = root.newton(f, startx);
	x0.print("x^3: root =", "{0,10:f10}");

	Write("__________Rosenbrock________\n");
	f = x => new vector(-2*(1-x[0])-200*x[0]*(x[1]-x[0]*x[0]), 200*(x[1]-x[0]*x[0]));
	startx = new vector(0, 0);
	x0 = root.newton(f, startx);
	x0.print("root = ");
    }
}
