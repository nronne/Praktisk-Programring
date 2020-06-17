using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    static void Main() {
	Write("==== Finding the extrenum of the Rosenbrock's Valley function with a=1 and b=100.  ==== \n\n");
	Write("Start guess of root:\n");
	Func<vector, vector> f = x => new vector(-2*(1-x[0])-200*x[0]*(x[1]-x[0]*x[0]), 200*(x[1]-x[0]*x[0]));
	vector startx = new vector(0, 0);
	startx.print();
	vector x0 = root.newton(f, startx);
	Write("\n After running newtons method, the found extremum is:\n");
	x0.print("");


	
    }
}
