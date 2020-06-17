using System;
using static System.Console;

public partial class root{
    public static vector newton(Func<vector, vector> f, vector x, double epsilon=1e-3, double dx=1e-7) {
	vector root = x;
	vector step;
	do
	{
	    /* calculate jacobian */
	    vector fx = f(root);
	    int i = fx.size;
	    int k = root.size;
	    /* Add assertion of i!=k (only square J) */
	    matrix jacobian = new matrix(i, k);
	    for (int r=0; r<i; r++) {
		for (int c=0; c<k; c++) {
		    vector deltax = root.copy();
		    deltax[c] += dx;
		    jacobian[r, c] = (f(deltax)[r]-f(root)[r])/dx;
		}
	    }
	    	
	    /* solve J * deltax = - f(x) with QR-factorization */
	    qrDecompositionGS qr = new qrDecompositionGS(jacobian);
	    step = qr.solve(-1*fx);
	    	
	    /* Do line search and choose lambda when (8) is fulfilled. */
	    double lambda = 1;
	    while(f(root+lambda*step).norm()>(1-lambda/2)*fx.norm() && lambda > 1/64) {
		lambda /= 2;
	    }
	    root += lambda*step;
	} while(f(x).norm()>epsilon && step.norm() > dx);
	
	return root;
    }
}
