using System;
using static System.Math;
using static System.Console;

public class minimizer {
    public static readonly double eps = 1e-7;
    
    public static vector qnewton(Func<vector, double> f, vector xstart, double acc=1e-3) {
	int nstep=0;
	int n = xstart.size;
	vector x = xstart;
	matrix B = new matrix(n, n);
	B.set_identity();
	vector fgrad, deltax;
	fgrad = gradient(f, x);
	deltax = - B*fgrad;
	    
	/* Perform step with linesearch */
	while(nstep<999) {
	    if (fgrad.norm() < acc) {
		break;
	    }
	    if (deltax.norm() < eps*x.norm()) {
		break;
	    }
	    
	    double fx = f(x);
	    double lambda = 1;
	    vector step = lambda*deltax;
	    while(f(x+step) > fx) {
		lambda /= 2;
		step = lambda*deltax;
		if (lambda < eps) {
		    B.set_identity();
		    /*
		      for(int i=0; i<step.size; i++) {
			step[i] = 0;
			} 
		    */
		    break;
		}
	    }
	    /* Update inverse Hessian matrix */
	    vector fstepgrad = gradient(f, x+step);
	    vector dy = fstepgrad - fgrad; //y
	    vector u = step - B*dy; 
	    if (Abs(step.dot(dy)) > eps) {
		B.update(u,u,1/(u%dy));
	    }
	    x += step;
	    fx = f(x);
	    fgrad = fstepgrad;
	    deltax = -B*fgrad;
	    nstep++;
	}
	
	return x;
    }//qnewton

    public static vector gradient(Func<vector, double> f, vector x) {
	vector grad = new vector(x.size);
	double dx;
	double fx = f(x);
	
	for (int i=0; i<x.size; i++) {
	    dx = Abs(x[i])*eps;
	    if (Abs(x[i])<Sqrt(eps)) dx = eps;
	    x[i] += dx;
	    grad[i] = (f(x)-fx)/dx;
	    x[i] -= dx;
	}
	return grad;
    }//gradient
}//minimizer
