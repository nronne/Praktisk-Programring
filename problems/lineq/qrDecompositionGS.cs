using System;
using static System.Math;
using static System.Console;

public class qrDecompositionGS{
    public matrix q {get;}
    public matrix r {get;}

    public qrDecompositionGS(matrix a) {
	r = new matrix(a.size2, a.size2);
	q = a.copy();
	this.modGramSchmidt();
    } // constructor; memory allocated here, not in main!
    
    void modGramSchmidt() {
	int n = q.size1; // rows
	int m = q.size2; // columns

	double length;
	double innerProd;
	for (int i = 0; i < m; i++) {
	    length = 0;
	    for (int t = 0; t<n; t++) {
		length += q[t, i]*q[t, i];
	    }
	    length = Sqrt(length);
	    r[i, i] = length;
	    for (int t = 0; t<n; t++) {
		q[t, i] = q[t, i]/length;
	    } // normalize q_i
	    

	    for (int j = i+1; j<m; j++) {
		innerProd = 0;
		for (int t = 0; t<n; t++) {
		    innerProd += q[t, i]*q[t, j];
		}
		r[i, j] = innerProd;
		for (int t = 0; t<n; t++) {
		    q[t, j] = q[t,j] - innerProd * q[t, i];
		}
	    } // Orthogonalize all other columns of a to q_i
	}

    } //modGramSchmidt

    
    public vector solve(vector b) {
	vector x = new vector(q.size2);
	vector c = q.transpose() * b;
	for (int i=x.size-1; i>=0; i--) {
	    x[i] = c[i];
	    for (int j=i+1; j<x.size; j++) {
		x[i] -= r[i,j]*x[j];
	    }
	    x[i] /= r[i,i];
	}
	return x;
    } //solve

    
    public matrix inverse() {
	if (q.size1 != q.size2) {
	    throw new ArgumentException("Matrix must be square!");
	}
	matrix inva = new matrix(q.size1, q.size2);
	vector ei = new vector(q.size1);
	vector xi = new vector(q.size1);
	for (int i=0; i<q.size1; i++) {
	    for (int j=0; j<q.size1; j++) {
		ei[j] = 0;
		if (i==j) ei[j] = 1;
	    }
	    xi = this.solve(ei);
	    for (int j=0; j<q.size1; j++) {
		inva[j, i] = xi[j];
	    }
	}
	return inva;
    } //inverse
    
} //qrDecompositionGS
