using System;
using static System.Console;
using static System.Math;
using System.IO;

class main {
    public static void Main() {
	double[] xs = {1,2,3,4,6,9,10,13,15};
	double[] ys = {117,100,88,72,53,29.5,25.2,15.2,11.1};
	vector x = new vector(xs);
	vector y = new vector(x.size);
	vector dy = new vector(x.size);
	for(int i=0; i<x.size; i++) {
	    y[i] = Log(ys[i]);
	    dy[i] = 0.05;
	}
	
	Func<double, double> f0 = (t) => 1;
	Func<double, double> f1 = (t) => -t;
	Func<double, double>[] fs = {f0, f1};
	ols myfit = new ols(fs, x, y, dy);
	vector c = myfit.fit();
	vector dc = myfit.fitUncertainty();
	Write("==== FIT RESULT ====\n");
	Write("          a              lambda\n ");
	Write($"{Exp(c[0]):f3} +/- {Exp(c[0])*dc[0]:f3}   {c[1]:f3} +/- {dc[1]:f3} \n");
	Write("====================\n\n");

	Write($"This gives life-time of Ra-224: {Log(2)/c[1]:f3} +/- {Log(2)/c[1]/c[1] * dc[1]:f3}\n");
	Write("i.e not within todays known value.\n");
	//myfit.covMatrix().print("Sigma = ");
	
	
	
    } // Main    
} // main
