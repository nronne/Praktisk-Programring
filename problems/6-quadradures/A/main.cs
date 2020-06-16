using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

class main {
    public static void Main() {
	Func<double, double> f = x => Sqrt(x);

	var inte = new Integrator(f, 0, 1, absAcc:10e-5, relAcc:10e-5);
	double q = inte.value;
	int n = inte.n;

	Write("==== TEST of integration routine ====\n");
	Write("i) integration of sqrt(x) from 0 to 1:\n");
	Write($"Result is {q} found with {n} recursion calls. \n");
	Write($"Difference from analytic result is: {q-2.0/3.0}\n\n");
	
	f = x => 4*Sqrt(1-x*x);

	inte = new Integrator(f, 0, 1, absAcc:10e-4, relAcc:10e-4);
	q = inte.value;
	n = inte.n;
	Write("ii) integration of 4*sqrt(1-x^2) from 0 to 1:\n");
	Write($"Result is {q} found with {n} recursion calls. \n");
	Write($"Difference from analytic result is: {q-PI}\n");
    }
}
