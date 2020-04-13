using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    static void Main() {
	Func<double, vector, vector> f = delegate(double x, vector y) {
	    return new vector(y[1], -y[0]);
	};
	rk sincos = new rk(f, 0, 2*PI, new vector(0, 1), storeVal:true);
	/* Write($"sin(1) = {sincos.yb[0]}\n");
	Write($"cos(1) = {sincos.yb[1]}\n"); */
	List<double> ts = rk.ts; // list to store intermediate t values
	List<vector> ys = rk.ys;// list to store intermediate f(t) valyes
	for (int i=0; i<ts.Count; i++) {
	    Write("{0:f10} {1:f15} {2:f15}\n", ts[i], ys[i][0], ys[i][1]);
	}
	
    }
}
