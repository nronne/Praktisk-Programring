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
	Write($"q = {q} with {n} recursion calls \n");
	Write($"diff = {q-2.0/3.0}\n");
	
	f = x => 4*Sqrt(1-x*x);

	inte = new Integrator(f, 0, 1, absAcc:10e-4, relAcc:10e-4);
	q = inte.value;
	n = inte.n;
	Write($"q = {q} with {n} recursion calls \n");
	Write($"diff = {q-PI}\n");
    }
}
