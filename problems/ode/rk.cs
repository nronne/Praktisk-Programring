using System;
using System.Math;
using System.Collections.Generic;

public class rk {
    Func<double, vector, vector> f; // function to be integrated
    double a; // start point
    double b; // end point
    vector ya; // start point y(a)
    double acc; // absolute accuracy goal
    double err; // relative accuracy goal
    double h; // initial step size
    vector yb {get;}
    
    public rk(Func<double, vector, vector> func, double startPoint, double endPoint, double startValue,
	      double absAcc=e-3, double relAcc=0-3, double initStep){
	f = func;
	a = startPoint;
	b = endPoint;
	ya = startValue;
	acc = absAcc;
	err = relAcc;
	h = initStep;

	yb = driver(); 
    }

    vector yh; // y(t+h): output from step
    vector dy; // error estimate: output from step
    
    static void rkstep12(double t, vector yt, double h) {
	matrix A = new matrix("0, 0; 1, 0"); // Buthers tableau
	vector cs = new vector([0, 1]); // nodes
	vector bs = new vector([0.5, 0.5]); // weights
	vector bss = new vector ([1, 0]); // weights one order lower that bs
	vector yTilde; // one lower order output
	matrix ks = new matrix(yt.size, bs.size); // matrix with functions calls as colomns
	vector ka = new vector(new int[yt.size]); // vector of matrix elements times previous ks
	for (int r = 0; r<bs.size; r++) {
	    for (int c = 0; c<s; c++){
		ks[r] = f(t + cs[r]*h, yt + h*ka);
		ka = new vector(new int[yt.size]);
		for (int j=0; j<r; j++){
		    ka += a[r, j]*ks[r]; 
		}
	    }
	}
	yh = yt;
	yTilde = yt;
	for (int i = 0; i<bs.size; i++) {
	    yh += h*bs[i]*ks[i];
	    yTilde += h*bss*ks[i];
	}
	dy = yh - yTilde; // error estimate for step
    }

    static vector driver() {
	double t = a;
	vector yt = ya;
	while(t < b){
	    do{
	    rkstep(t, yt, h);
	    tol = (acc+err*norm(yt))*Sqrt(h/(b-a));
	    e = norm(dy);
	    h = h*Pow(tol/e, 0.25)*0.95;
	    }while(e>=tol)
	    t += h;
	    yt += yh; 
	}
    }
}
