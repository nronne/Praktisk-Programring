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
	      bool storeVal=false, double absAcc=1e-2, double relAcc=1e-2,
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

    /*
      rk45
      matrix A = new matrix($"0,0,0,0,0,0;0.25,0,0,0,0,0;{3.0/32},{9.0/32},0,0,0,0;{1932.0/2197},{-7200.0/2197},{7296.0/2197},0,0,0;{439.0/216},{-8},{3680.0/513},{-845/4104},0,0;{-8.0/27},2,{-3544.0/2565},{1859.0/4104},{-11.0/40},0"); // Buthers tableau
      vector cs = new vector(new double[] {0.0, 0.25, 3.0/8, 12/13, 1, 0.5}); // nodes
      vector bs = new vector(new double[] {16.0/135, 0, 6656.0/12825, 28561.0/56430, -9.0/50, 2.0/55}); // weights
      vector bss = new vector(new double[] {25.0/216, 0, 1408.0/2565, 2197.0/4104, -1.0/5, 0}); // weights one order lower that bs
     */
    /*

    static vector[] rkstep23(double t, vector yt, double h) {
	matrix A = new matrix($"0,0,0,0;0.5,0,0,0;0,{3.0/4},0,0;{2.0/9},{1.0/3},{4.0/9},0"); // Buthers tableau
	vector cs = new vector(new double[] {0.0, 0.5, 3.0/4, 1}); // nodes
	vector bs = new vector(new double[] {2.0/9, 1.0/3, 4.0/9, 0}); // weights
	vector bss = new vector(new double[] {7.0/24, 1.0/4, 1.0/3, 1.0/8}); // weights one order lower that bs
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
    */
    
}//rk
