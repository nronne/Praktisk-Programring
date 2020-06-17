using System;
using static System.Math;
using static System.Console;

class main {
    public static void Main() {
	/* Test of functionality of neural network */
	Func<double, double> f = (t) => Cos(5*t-1)*Exp(-t*t);
	Func<double, double> activation = (t) => t*Exp(-t*t);
	int hiddenLayers = 15;
	ann testNetwork = new ann(hiddenLayers, activation);
	
	int numData = 100;
	double a=-1, b=1;
	vector x = new vector(numData);
	vector y = new vector(numData);
	for(int i=0; i<numData; i++) {
	    x[i] = a+(b-a)*i/(numData-1);
	    y[i] = f(x[i]);
	    Write($"{x[i]} {y[i]}\n");
	}

	vector p = new vector(hiddenLayers*3);
	for(int i =0; i<hiddenLayers; i++) {
	    p[i*3] = a+(b-a)*i/(hiddenLayers-1);
	    p[i*3+1] = 1;
	    p[i*3+2] = 1;
	}
	testNetwork.p = p;
	testNetwork.train(x, y);

	/* 
	   See how well it predicts on unseen data
	 */
	for(double q=-1.0; q<1.0; q+=0.05) {
	    double predictX = testNetwork.predict(q);
	    Error.Write($"{q} {predictX}\n");
	}
				     
       
    }//Main
}//main
