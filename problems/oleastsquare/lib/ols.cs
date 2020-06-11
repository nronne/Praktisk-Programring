using System;
using static System.Console;
using static System.Math;

public class ols {
    vector c;
    vector dc;
    matrix sigma;
    qrDecompositionGS qr;
    
    public ols(Func<double,double>[] fs, vector x, vector y, vector dy) {
	int m = fs.Length;
	int n = y.size;
	matrix a = new matrix(n,m);
	vector b = new vector(n);
       	for (int i=0; i<n; i++) {
	    b[i] = y[i]/dy[i];
	    for (int k=0; k<m; k++) {
		a[i,k] = fs[k](x[i])/dy[i];
	    }
	} // matrices and vector for qr-demposition
	qr = new qrDecompositionGS(a);
	c = qr.solve(b);
    } //constructor

    public vector fit() {
	return c;
    }

    public matrix covMatrix() {
	this.covariance();
	return sigma;
    }

    public vector fitUncertainty() {
	sigma = this.covMatrix();
	dc = new vector(c.size);
	for (int i = 0; i<c.size; i++) {
	    dc[i] = Sqrt(sigma[i,i]);
	}
	return dc;
    }

    void covariance() {
	matrix sigmaInv = qr.r.transpose() * qr.r;
	qrDecompositionGS cov = new qrDecompositionGS(sigmaInv);
	sigma = cov.inverse();
    }
    
}
