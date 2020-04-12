using System;
using static System.Console;
using System.Collections.Generic;

class main {
    static void Main() {
	Func<double, vector, vector> f = delegate(double x, vector y) {
	    return new vector(y[1], -y[0]);
	};
	rk sin = new rk(f, 0, 2, new vector(1, 0));
	(sin.yb).print("sin(2)=");
    }
}
