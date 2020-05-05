using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

public class Integrator {
    static Func<double, double> f;
    static double acc;
    static double eps;
    static int nrec;
    static int nfunc;
    public double value {get; set;}
    public int n {get; set;}
    public int counter {get; set;}
    
    public Integrator(Func<double, double> func, double start, double end
		      , double absAcc=10e-2, double relAcc=10e-2, string varTrans=null) {
	acc = absAcc;
	eps = relAcc;
	
	double a = start;
	double b = end;
	if (varTrans==null) {
	    f = func;
	    value = adapt(a, b);
	}
	else if (varTrans=="CC") {
	    f = (t) => func((b+a)/2.0 + (b-a)/2.0 * Cos(t))*Sin(t)*(b-a)/2;
	    value = adapt(0, PI);
	}
	else {
	    Write("Wrong variable transformation type entered. Will proceed without transform \n");
	    f = func;
	    value = adapt(a, b);
	}
	n = nrec;
	counter = nfunc;
	
    }

    static double adapt24(double f2, double f3, double a, double b,  double delta) {
	double f1 = f(a+(b-a)/6); nfunc++;
	double f4 = f(a+5*(b-a)/6); nfunc++;
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
	double q = (f1+f2+f3+f4)/4*(b-a);
	double error = Abs(Q-q);
	double tol = delta+eps*Abs(Q);
	if(error < tol) {
	    return Q;
	}
	else {
	    nrec++;
	    if (nrec < 999){
		double Q1 = adapt24(f1, f2, a, (a+b)/2.0, delta/Sqrt(2.0));
		double Q2 = adapt24(f3, f4, (a+b)/2.0, b, delta/Sqrt(2.0));
		return Q1+Q2;
	    }
	    else {
		Write("Maximum recursice depth reached! Returning best value.\n");
		return Q;
	    }
	}
	
    }

    static double adapt(double a, double b) {
	double f2 = f(a+2*(b-a)/6);
	double f3 = f(a+4*(b-a)/6);
	nrec = 0;
	nfunc=2;
	return adapt24(f2, f3, a, b, acc);
    }
    
}
