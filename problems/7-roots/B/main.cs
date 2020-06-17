using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;

class main {
    static void Main() {
	
	Write("==== Schrödinger equation for hydrogen with shooting method ====\n\n");
	Write("Found ground state energy for rmax=8:\n");
	double energy = hydrogen(8.0);
	Write($"epsilon:   {energy:f2}\n");
	Write($"deviation: {energy+0.5:f2}\n");

	Fe(energy, 8.0, waveFun:true);
    }

    static double hydrogen(double rmax) {
	Func<vector, vector> M = (vector x) => {
	    double e = x[0];
	    double frmax=Fe(e, rmax);
	    return new vector(frmax);   
	};
	
	/* Find root of M */	
	vector startx = new vector(-1.0);
	vector x0 = root.newton(M, startx, epsilon:1e-5);
	double energy = x0[0];
	return energy;
    }

    static double Fe(double e, double r, bool waveFun=false) {
	double rmin = 1e-3;
	if (r<rmin) {
	    return r - r*r;
	}
	
	Func<double, vector, vector> s = delegate(double x, vector y) {
	    return new vector(y[1], 2*(-1/x-e)*y[0]);
	};		
	vector ymin = new vector(rmin-rmin*rmin, 1-2*rmin);
	rk swave = new rk(s, rmin, r, ymin, initStep:0.001, storeVal:waveFun); //my own 32 stepper
	
	if(waveFun){
	    List<double> rs = rk.ts;
	    List<vector> fs = rk.ys;
		
	    var data = new StreamWriter("data.txt");
	    for(int i=0; i<rs.Count; i++) {
		data.Write($"{rs[i]} {fs[i][0]} {rs[i]*Exp(-rs[i])}\n");
	    }
	    
	    data.Close();
	}
	
	return swave.yb[0];
    }
}
