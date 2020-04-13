using System;
using static System.Console;
using System.Collections.Generic;

class main {
    static void Main() {
	Func<double, vector, vector> f = delegate(double x, vector y) {
	    return new vector(y[1], -y[0]);
	};
	rk sincos = new rk(f, 0, 1, new vector(0, 1), initStep:1.0);
	Write($"sin(1) = {sincos.yb[0]}\n");
	Write($"cos(1) = {sincos.yb[1]}\n");
    }
}
