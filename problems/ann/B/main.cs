using System;
using static System.Math;
using static System.Console;

class main {
    public static void Main() {
	/* Test of functionality of neural network */
	Func<double, double> f = (t) => Cos(t);
	Func<double, double> fprime = (t) => -Sin(t);
	Func<double, double> F = (t) => Sin(t);
	int hiddenLayers = 3;
	annGauss gaussian3 = new annGauss(hiddenLayers);
	
	int numData = 100;
	double a=0, b=2*PI;
	vector x = new vector(numData);
	vector y = new vector(numData);
	for(int i=0; i<numData; i++) {
	    x[i] = a+(b-a)*i/(numData-1);
	    y[i] = f(x[i]);
	    Write($"{x[i]} {y[i]} {fprime(x[i])} {F(x[i])}\n");
	}

	vector p = new vector(hiddenLayers*3);
	for(int i =0; i<hiddenLayers; i++) {
	    p[i*3] = a+(b-a)*i/(hiddenLayers-1);
	    p[i*3+1] = 1;
	    p[i*3+2] = 1;
	}
	gaussian10.p = p;
	gaussian10.train(x, y);

	/* 
	   See how well it predicts on unseen data
	 */
	for(double q=a; q<b; q+=0.05) {
	    double predictfx = gaussian3.predict(q);
	    double predictfprimex = gaussian3.derivative(q);
	    double predictFx = gaussian3.antiDerivative(q);
	    Error.Write($"{q} {predictfx} {predictfprimex} {predictFx}\n");
	}
				     
    }//Main
}//main
