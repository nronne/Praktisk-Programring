using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

class main {
    public static void Main() {
	
	Func<double, double> f = x => Exp(-x*x);
	double a = double.NegativeInfinity;
	double b = double.PositiveInfinity;

	
	var inte = new Integrator(f, a, b, absAcc:10e-3, relAcc:10e-3);
	double q = inte.value;
	int n = inte.n;
	int counter = inte.counter;
	Write("===== Test of integration with infinity as limit ====\n\n");

	Write("   exp(-x^2) from -infinity to infinity.\n");
	Write("Analytic result:      sqrt(pi)\n\n");
	Write($"  o4av:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-Sqrt(PI)}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");
	
	q  = quad.o8av(f, a, b, acc:1e-3, eps:1e-3);
	
	Write($"  o8av from matlib:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-Sqrt(PI)}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n");


	Write("_________________________________________________\n\n");	
	f = x => 1/(x+1)/Sqrt(x);
        a = 0;
	b = double.PositiveInfinity;
	
	inte = new Integrator(f, a, b, absAcc:10e-3, relAcc:10e-3);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write("  1/(x+1)/sqrt(x) from 0 to infinity.\n");
	Write("Analytic result:      pi\n\n");

	Write($"  o4av:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-PI} \n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");
	
	q  = quad.o8av(f, a, b, acc:1e-3, eps:1e-3);
	
	Write($"  o8av from matlib:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-PI}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");

    }
}
