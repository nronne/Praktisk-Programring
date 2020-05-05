using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    public static void Main() {
	Write("_________Rosenbrock's valley function_______\n");
	Func<vector, double> f = delegate(vector x) {
	    double val = (1-x[0])*(1-x[0])+100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
	    return val;
	};
	vector xstart = new vector(0.0, 0.0);
	vector xmin = minimizer.qnewton(f, xstart);
	xmin.print("xmin=");

	Write("_________Himmelblau's function_______\n");
	f = delegate(vector x) {
	    double val = Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7, 2);
	    return val;
	};
	xstart = new vector(0.0, 0.0);
	xmin = minimizer.qnewton(f, xstart);
	xmin.print("xmin=");
	    
    }
}
