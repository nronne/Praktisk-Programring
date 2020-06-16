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
	Write("===== Test of integration routines with Clenshaw-Curtis transform ====\n\n");
	Write("=======================================================================\n");
	Write("i) 1/sqrt(x) from 0 to 1.\n\n");
	Write($"  o4a with Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-2.0}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");
	
	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"  o4a without Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-2.0}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");
	
	q  = quad.o8av(f, 0, 1, acc:1e-3, eps:1e-3);
	
	Write($"  o8av from matlib:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-2.0}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");

	Write("______________________________________________\n\n");

	Write("ii) ln(x)/sqrt(x) from 0 to 1.\n\n");
	f = x => Log(x)/Sqrt(x);
	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3, varTrans:"CC");
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"  o4a with Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q+4.0}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");


	inte = new Integrator(f, 0, 1, absAcc:10e-3, relAcc:10e-3);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"  o4a without Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q+4.0}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");

	q  = quad.o8av(f, 0, 1, acc:1e-3, eps:1e-3);
	
	Write($"  o8av from matlib:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q+4.0}\n");
	Write($"absulute accuracy:   {10e-3}\n");
	Write($"relative accuracy:   {10e-3}\n\n");

	Write("______________________________________________\n\n");

	Write("iii) 4*sqrt(1-x*x).\n\n");
	f = x => 4*Sqrt(1-x*x);
	inte = new Integrator(f, 0, 1, absAcc:10e-5, relAcc:10e-5, varTrans:"CC");
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"  o4a with Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-PI}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-5}\n");
	Write($"relative accuracy:   {10e-5}\n\n");


	inte = new Integrator(f, 0, 1, absAcc:10e-5, relAcc:10e-5);
	q = inte.value;
	n = inte.n;
	counter = inte.counter;
	Write($"  o4a without Clenshaw-Curtis transforms:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-PI}\n");
	Write($"Function calls:      {counter}\n");
	Write($"Recursion calls:     {n}\n");
	Write($"absulute accuracy:   {10e-5}\n");
	Write($"relative accuracy:   {10e-5}\n\n");
	
	q  = quad.o8av(f, 0, 1, acc:10e-5, eps:10e-5);
	
	Write($"  o8av from matlib:\n");
	Write($"Result:              {q}\n");
	Write($"Deviation:           {q-PI}\n");
	Write($"absulute accuracy:   {10e-5}\n");
	Write($"relative accuracy:   {10e-5}\n\n");
	
    }
}
