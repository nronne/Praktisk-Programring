using System;
using static System.Math;
using System.Collections.Generic;

public class rk {
    static Func<double, vector, vector> f; // function to be integrated
    static double a; // start point
    static double b; // end point
    static vector ya; // start point y(a)
    static double acc; // absolute accuracy goal
    static double err; // relative accuracy goal
    static double h; // initial step size
    public vector yb; // integrated result at y(b)
    
    public rk(Func<double, vector, vector> func, double startPoint, double endPoint, vector startValue,
	      double absAcc=10e-3, double relAcc=10e-3, double initStep=0.01){
	f = func;
	a = startPoint;
	b = endPoint;
	ya = startValue;
	acc = absAcc;
	err = relAcc;
	h = initStep;

	yb = driver(); 
    }

    static vector yh; // y(t+h): output from step
    static vector dy; // error estimate: output from step
    
    static void rkstep12(double t, vector yt, double h) {
	matrix A = new matrix("0.0,0.0;1.0,0.0"); // Buthers tableau
	vector cs = new vector(0.0, 1.0); // nodes
	vector bs = new vector(0.5, 0.5); // weights
	vector bss = new vector(1.0, 0.0); // weights one order lower that bs
	vector yTilde; // one lower order output
	matrix ks = new matrix(yt.size, bs.size); // matrix with functions calls as colomns
	vector ka = new vector(yt.size); // vector of matrix elements times previous ks
	for (int i = 0; i<yt.size; i++) {
	    ka[i] = 0;
	}
	for (int r = 0; r<bs.size; r++) {
	    for (int c = 0; c<r; c++){
		ks[r] = f(t + cs[r]*h, yt + h*ka);
		
		for (int i = 0; i<yt.size; i++) {
		    ka[i] = 0;
		}
		for (int j=0; j<r; j++){
		    ka += A[r, j]*ks[r];
		}
	    }
	}
	yh = yt;
	yTilde = yt;
	for (int i = 0; i<bs.size; i++) {
	    double bi = bs[i];
	    double bsi = bss[i];
	    yh += h*bi * ks[i];
	    yTilde += h*bsi*ks[i];
	}
	dy = yh - yTilde; // error estimate for step
    }

    static vector driver() {
	double t = a;
	vector yt = ya;
	double e, tol;
	while(t < b){
	    do{
	    rkstep12(t, yt, h);
	    tol = (acc+err*yt.norm())*Sqrt(h/(b-a));
	    e = dy.norm();
	    h = h*Pow(tol/e, 0.25)*0.95;
	    }while(e>=tol);
	    t += h;
	    yt += yh; 
	}
	return yt;
    }//driver
}//rk
