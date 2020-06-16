using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

public class rk {
    static Func<double, vector, vector> f; // function to be integrated
    static double a; // start point
    static double b; // end point
    static vector ya; // start point y(a)
    static double acc; // absolute accuracy goal
    static double err; // relative accuracy goal
    static double h; // initial step size
    static int nMax;
    public vector yb; // integrated result at y(b)
    static public List<double> ts; // list to store intermediate t values
    static public List<vector> ys; // list to store intermediate f(t) valyes
        
    public rk(Func<double, vector, vector> func, double startPoint, double endPoint, vector startValue,
	      bool storeVal=false, double absAcc=10e-3, double relAcc=10e-3,
	      double initStep=0.1, int limit=999){
	f = func;
	a = startPoint;
	b = endPoint;
	ya = startValue;
	acc = absAcc;
	err = relAcc;
	h = initStep;
	nMax = limit;
	if (storeVal) {
	    ts = new List<double>();
	    ys = new List<vector>();
	}
	yb = driver(); 
    }

    static vector[] rkstep12(double t, vector yt, double h) {
	matrix A = new matrix("0,0;1,0"); // Buthers tableau
	vector cs = new vector(0.0, 1.0); // nodes
	vector bs = new vector(0.5, 0.5); // weights
	vector bss = new vector(1.0, 0.0); // weights one order lower that bs
	vector yTilde; // one lower order output
	matrix ks = new matrix(yt.size, bs.size); // matrix with functions calls as colomns
	vector ka = new vector(yt.size); // vector of matrix elements times previous ks
	for (int i = 0; i<yt.size; i++) {
	    ka[i] = 0;
	}
	int r = 0;
	while (r<bs.size) {
	    ks[r] = f(t + cs[r]*h, yt + h*ka);

	    for (int i = 0; i<yt.size; i++) {
		ka[i] = 0;
	    }
	    r++;
	    if (r<bs.size){
		for (int c = 0; c<(r); c++){
		    ka += A[r, c]*ks[c];
		}
	    }
	}
	vector yh = yt;
	yTilde = yt;
	for (int i = 0; i<bs.size; i++) {
	    double bi = bs[i];
	    double bsi = bss[i];
	    yh += h*bi * ks[i];
	    yTilde += h*bsi*ks[i];
	}
	vector dy = yh - yTilde; // error estimate for step
	vector[] result = {yh, dy};
	return result;
    }

    static vector driver() {
	double t = a;
	vector yt = ya;
	vector yh, dy;
	double e, tol, hOld;
	int s, nSteps=0;
	if(ts!=null) {
	    ts.Clear();
	    ts.Add(t);
	}
	if(ys!=null) {
	    ys.Clear();
	    ys.Add(yt);
	}

	while(t < b){
	    s=0;
	    if (nSteps > nMax) {
		Error.Write("To many steps taken! \n");
		return yt;
	    }
	    do{
		if(t+h>b) {
		    h=b-t;
		}
		vector[] trialStep = rkstep12(t, yt, h);
		yh = trialStep[0];
		dy = trialStep[1];
		tol = (acc+err*yt.norm())*Sqrt(h/(b-a));
		e = dy.norm();
		hOld = h;
		h = h*Pow(tol/e, 0.25)*0.95;
		s++;
		
	    }while(e>tol);
	    Error.Write("Step taken with step size: {0} \n Number of bad steps: {1} \n", hOld, s-1);
	    t += h;
	    yt = yh;
	    if(ts!=null) {
		ts.Add(t);
	    }
	    if(ys!=null) {
		ys.Add(yt);
	    }
	    nSteps++;
	}
	return yt;
    }//driver
}//rk
