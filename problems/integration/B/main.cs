using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

class main {
    public static void Main() {
	
	Func<double, double> f = x => 1/Sqrt(x);

	var inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3, varTrans:"CC");
	double q = inte.value;
	int n = inte.n;
	int counter = inte.counter;
	Write("------------∫_0^1 dx 1/√(x) = 2 -------------\n");
	Write($"q = {q} with {n} recursion calls and {counter} function calls for Clenshaw-Curtis transform\n");
	Write($"diff = {q-2.0}\n");

	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"q = {q} with {n} recursion calls and {counter} function calls without Clenshaw-Curtis transform\n");
	Write($"diff = {q-2.0}\n");

	Write("------------∫_0^1 dx ln(x)/√(x) = -4 -------------\n");
	f = x => Log(x)/Sqrt(x);
	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3, varTrans:"CC");
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"q = {q} with {n} recursion calls and {counter} function calls with Clenshaw-Curtis transform\n");
	Write($"diff = {q+4.0}\n");

	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"q = {q} with {n} recursion calls and {counter} function calls without Clenshaw-Curtis transform\n");
	Write($"diff = {q+4.0}\n");


	Write("------------∫_0^1 dx 4√(1-x²) = π -------------\n");
	f = x => 4*Sqrt(1-x*x);
	inte = new Integrator(f, 0, 1, absAcc:10e-5, relAcc:10e-5, varTrans:"CC");
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"q = {q} with {n} recursion calls and {counter} function calls with Clenshaw-Curtis transform\n");
	Write($"diff = {q-PI}\n");

	inte = new Integrator(f, 0, 1, absAcc:10e-5, relAcc:10e-5);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"q = {q} with {n} recursion calls and {counter} function calls without Clenshaw-Curtis transform\n");
	Write($"diff = {q-PI}\n");
	
    }
}
