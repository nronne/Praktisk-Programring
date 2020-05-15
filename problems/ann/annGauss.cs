using System;
using static System.Math;
using static System.Console;

public class annGauss : ann {

    static Func<double, double> gaussian = (x) => Exp(-x*x);

    static Func<double, double> gaussianDeri = (x) => -2*x*Exp(-x*x);

    static Func<double, double> gaussianAnti = (x) => Sqrt(PI)/2*myFun.erf(x);
        
    public annGauss(int nNeurons) : base(nNeurons, gaussian) {
	
    }

    public double derivative(double x) {
	double sum = 0;
	for(int i = 0; i<n; i++) {
	    double a = p[i*3];
	    double b = p[i*3+1];
	    double w = p[i*3 +2];
	    sum += gaussianDeri((x-a)/b)*w/b;
	}
	return sum;
    }

    public double antiDerivative(double x) {
	double sum = 0;
	for(int i = 0; i<n; i++) {
	    double a = p[i*3];
	    double b = p[i*3+1];
	    double w = p[i*3 +2];
	    sum += gaussianAnti((x-a)/b)*w*b;
	}
	return sum;
    }
    
}
