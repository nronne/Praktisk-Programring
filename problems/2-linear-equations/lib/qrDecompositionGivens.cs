using System;
using static System.Math;
using static System.Console;

public class qrDecompositionGivens{
    public matrix G {get;}

    public qrDecompositionGivens(matrix a) {
	G = a.copy();
	this.Givens();
    } //constructor; memory allocated in class!

    void Givens() {
	int n = G.size1;
	int m = G.size2;
	double theta, xq, xp;
	for (int q=0; q<m; q++) {
	    for (int p=q+1; p<n; p++) {
		theta = Atan2(G[p,q],G[q,q]);
		    for (int k=q; k<m; k++) {
			xq = G[q, k];
			xp = G[p, k];
			G[q, k] = xq*Cos(theta)+xp*Sin(theta);
			G[p, k] = -xq*Sin(theta)+xp*Cos(theta);
		    }
		G[p, q] = theta;
	    }
	}
    }//Givens

    public vector solve(vector b) {
	vector x = givensB(b);
	for (int i=b.size-1; i>=0; i--) {
	    double sum=0;
	    for (int j=i+1; j<b.size; j++) {
		sum += G[i,j]*x[j];
	    }
	    x[i] =(x[i]-sum)/ G[i,i];
	}
	return x;
    }//solve

    public vector givensB(vector b) {
	vector x = b.copy();
	double theta;
	double c;
	double s;
	double x_p;
	double x_q;
	for(int q = 0; q < G.size2; q++) {
	    for(int p = q+1; p < G.size1; p++) {
		theta = G[p, q];
		c = Cos(theta);
		s = Sin(theta);
		x_p = c*x[q] + s*x[p];
		x_q = -s*x[q] + c*x[p];
		
		x[q] = x_p;
		x[p] = x_q;
	    }
	}
	return x;
    }
    
}
