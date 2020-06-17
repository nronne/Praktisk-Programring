using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    public static void Main() {
	Write("==== Finding the minimum of the Rosenbrock's Valley function with a=1 and b=100.  ==== \n\n");
	Write("Start guess of minimum:");
	Func<vector, double> f = delegate(vector x) {
	    double val = (1-x[0])*(1-x[0])+100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
	    return val;
	};
	vector xstart = new vector(0.0, 0.0);
	xstart.print();
	vector xmin = minimizer.qnewton(f, xstart);
	Write("\n The found minimum is:\n");
	xmin.print();
	Write("\n Minimum according to Wikipedia is:\n");
	Write("         1          1\n");

	Write("\n \n ==== Finding the minimum of Himmelblau's function.  ====\n\n");
	f = delegate(vector x) {
	    double val = Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7, 2);
	    return val;
	};
	Write("Start guess of minimum:\n");
	xstart = new vector(0.0, 0.0);
	xstart.print();
	xmin = minimizer.qnewton(f, xstart);
	Write("\n The found minimum is:\n");
	xmin.print();
	Write("\n One minimum according to Wikipedia is:\n");
	Write("       3.0         2.0\n");
	    
    }
}
