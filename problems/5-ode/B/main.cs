using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    static void Main() {
	double N = 550; //population in ten thousands
	double Tr = 15; //recovery time in days
	double Tc = 0.01; //time between contacts in days
	    
	Func<double, vector, vector> f = delegate(double x, vector y) {
	    double n = y[0] + y[1] + y[2];
	    return new vector(-y[1]*y[0]/(n*N*Tc), y[1]*y[0]/(n*N*Tc)-y[1]/Tr, y[1]/Tr);
	};
	
	rk sir = new rk(f, 0, 150, new vector(550, 1, 0), storeVal:true);
	/* Write($"sin(1) = {sincos.yb[0]}\n");
	Write($"cos(1) = {sincos.yb[1]}\n"); */
	List<double> ts = rk.ts; // list to store intermediate t values
	List<vector> ys = rk.ys;// list to store intermediate f(t) valyes
	for (int i=0; i<ts.Count; i++) {
	    Write("{0:f10} {1:f15} {2:f15} {3:f15}\n", ts[i], ys[i][0], ys[i][1], ys[i][2]);
	}
	
    }
}
