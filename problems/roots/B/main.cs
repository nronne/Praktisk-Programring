using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

class main {
    static void Main() {
	/* Find M by solving ODE for rmax=8 */
	double rmax = 10.0;
	Func<vector, vector> M = x => new vector(Fe(x[0], rmax));
	
	/* Find root of M */
	
	vector startx = new vector(-1.0);
	vector x0 = root.newton(M, startx);
	double e = x0[0];
	Write($"energy of s-wave ground state: {e} Hartree \n");

	/* Make data for plot {r, Fe(e, r), r*exp(-r)} with e from solution*/
	
	


    }

    static double Fe(double e, double r) {
	double rmin = 1e-3;
	if (r<rmin) {
	    return r - r*r;
	}
	
	Func<double, vector, vector> s = delegate(double x, vector y) {
	    return new vector(y[1], -2*(1/x+e)*y[0]);
	};
	vector ymin = new vector(rmin-rmin*rmin, 1-2*rmin);
	rk swave = new rk(s, rmin, r, ymin, initStep:0.001);
	return swave.yb[0];
	
    }
}
