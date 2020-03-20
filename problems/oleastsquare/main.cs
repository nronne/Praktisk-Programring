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
	
	Func<double, double> f0 = (x) => 1;
	Func<double, double> f1 = (x) => -x;
	Func<double, double>[] fs = {f0, f1};
	ols myfit = new ols(fs, x, y, dy);
	vector c = myfit.fit();
	c.print("c=");

	StreamWriter fit = new StreamWriter("out.txt");
	StreamWriter data = new StreamWriter("data.txt");
	
	for (double t=0.75; t<16; t+=0.25) {
	    fit.Write($"{t, 10:f8} {Exp(c[0])*Exp(-c[1]*t), 15:f16} \n");
	}

	for (int d=0; d<x.size; d++) {
	    data.Write($"{x[d], 10:f8} {ys[d], 15:f16} {ys[d]*0.05, 15:f16} \n");
	}

	fit.Close();
	data.Close();

	myfit.covMatrix().print("Sigma = ");
	myfit.fitUncertainty().print("dc = ");
	vector dc = myfit.fitUncertainty();

	StreamWriter fitwunc = new StreamWriter("outwunc.txt");
	for (double t=0.75; t<16; t+=0.25) {
	    fitwunc.Write($"{t, 10:f8}" +
                        $" {Exp(c[0])*Exp(-c[1]*t), 15:f16}" +
                        $" {Exp(c[0]+dc[0])*Exp(-(c[1]+dc[1])*t), 15:f16}" +
                        $" {Exp(c[0]-dc[0])*Exp(-(c[1]-dc[1])*t), 15:f16} \n");
	}
	fitwunc.Close();
	
    } // Main    
} // main
