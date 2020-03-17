using System;
using static System.Math;
using static System.Console;

public class qrDecompositionGivens{
    public matrix qr {get;}

    public qrDecompositionGivens(matrix a) {
	qr = a.copy();
	this.Givens();
    } //constructor; memory allocated in class!

    void Givens() {
	int n = qr.size1;
	int m = qr.size2;
	double theta, xq, xp;
	for (int q=0; q<m; q++) {
	    for (int p=q+1; p<n; p++) {
		theta = Atan2(qr[p,q],qr[q,q]);
		    for (int k=q; k<m; k++) {
			xq = qr[q, k];
			xp = qr[p, k];
			qr[q, k] = xq*Cos(theta)+xp*Sin(theta);
			qr[p, k] = -xq*Sin(theta)+xp*Cos(theta);
		    }
		qr[p, q] = theta;
	    }
	}
    }//Givens

    public vector solve(vector b) {
	vector x = b.copy();
	vector gb = this.GivensB(x);
	for (int i=b.size-1; i>=0; i--) {
	    x[i] = gb[i];
	    for (int j=i+1; j<b.size; j++) {
		x[i] -= qr[i,j]*x[j];
	    }
	    x[i] /= qr[i,i];
	}
	return x;
    }//solve
    
    vector GivensB(vector b) {
	int n = qr.size1;
	int m = qr.size2;
	double theta;
	for (int q=0; q<m; q++) {
	    for (int p=q+1; p<n; p++) {
		theta = qr[p, q];
		b[q] = b[q]*Cos(theta) + b[p]*Sin(theta);
		b[p] = -b[q]*Sin(theta) + b[p]*Cos(theta);
	    }
	}
	return b;
    }//GivensB
    
    
}
