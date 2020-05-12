using System;
using static System.Math;
using static System.Console;

public class ann {
    int n; //number of neurons
    Func<double, double> f; //activation function
    public vector p{get; set;} //initial network parameters: a_i, b_i, w_i

    public ann(int nNeurons,
	       Func<double, double> activationFunc) {
	n = nNeurons;
	f = activationFunc;
	p = new vector(3*n);
    }//constructor
     
    /* 
       train to interpolate the given table {x, y}
    */
    public void train(vector x, vector y) {
	Func<vector, double> F = delegate(vector t) {
	    double sum = 0;
	    p = t;
	    for(int i=0; i<x.size; i++) {
		sum += (feedforward(x[i])-y[i])*(feedforward(x[i])-y[i]);
	    }
	    
	    return sum/x.size;
	};
	vector tInit = p;
	vector tmin = minimizer.qnewton(F, tInit);
    }//train

    /*
      predict function value at x
     */
    public double predict(double x) {
	return feedforward(x);
    }//predict
    

    /* 
       apply the neural network to input parameters
    */
    double feedforward(double x) {
	double sum = 0;
	for(int i = 0; i<n; i++) {
	    double a = p[i*3];
	    double b = p[i*3+1];
	    double w = p[i*3 +2];
	    sum += f((x-a)/b)*w;
	}
	return sum;
    }//feedforward

    
}//ann
