using System;
using static System.Console;
using static System.Math;

public static class bessel{
    public static double Bessel(double x, int n=0){
        Func<double, vector, vector> j = delegate(double x, vector y){
            return new vector(y[1], -2*y[1]/x-(x*x-n*(n+1))/(x*x) * y[0]);
        };//j
	double a=0.0001;
	double y0 = 0;
	double y1 = 0;
        vector ya;
        if (n == 0) {
	    y0 = 1-a*a/2;
	    y1 = -3/2*a;		
	}
        else if (n == 1) {
	    y0 = a/3;
	    y1 = 1/3 - a*a/10;
	}
	else if (n == 2) {
	    y0 = a*a/15;
	    y1 = 2*a/15;
	}
	else if (n == 3) {
	    y0 = 0;
	    y1 = a*a/35;
	}
	else if (n < 0) {
	    Write("Error! Negative or non-int not implement. \n");
	}
	ya = new vector(y0, y1);
	vector r = ode.rk23(j, a, ya, x, acc:1e-4, eps:1e-4);
        return r[0];
    }//Bessel
}//bessel
