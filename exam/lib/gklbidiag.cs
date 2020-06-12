using System;
using static System.Math;

public class bidiag {
    public matrix A;
    public matrix B;
    public matrix U;
    public matrix V;

    public bidiag(matrix A) {
	this.A = A;
	gkl(A);
    }//constructor
    
    public void gkl(matrix A) {
	int m = A.size1;
	int n = A.size2;
	double alpha, beta;
	beta=0;
	
	vector v = new vector(n);
	vector u = new vector(m);
	for(int i=0; i<n; i++) {v[i]=1.0/Sqrt(n);}
	for(int i=0;i<m; i++) {u[i]=0;}
	
	U = new matrix(m, n);
	V = new matrix(n, n);
	B = new matrix(n, n);
	
	for(int k=0; k<n; k++) {
	    for(int i=0; i<n; i++) {V[i, k] = v[i];}
	    u = (A*v) - beta*u;
	    alpha = u.norm();
	    u /= alpha;
	    for(int i=0; i<m; i++) {U[i, k] = u[i];}
	    v = (A.transpose() * u) - alpha*v;
	    beta = v.norm();
	    v /=beta;
	    B[k,k]=alpha;
	    if(k<n-1) {
		B[k,k+1]=beta;
	    }
	}
    }//gkl

    public vector solver(vector b) {
	vector x = new vector(A.size1);
	vector c = U.transpose() * b;
	for (int i=x.size-1; i>=0; i--) {
	    x[i] = c[i];
	    if(i+1<x.size){
		x[i] -= B[i, i+1]*x[i+1];
	    }
	    
	    x[i] /= B[i,i];
	}

	x = V*x;
	return x;
    } //solver

    public double determinant() {
	if (A.size1 != A.size2) {
	    throw new ArgumentException("Matrix must be square!");
	}
	double d = 1;
	for(int i=0; i<B.size1; i++){
	    d *= B[i,i];
	}
	return d;
    }
    
    public matrix inverse() {
	if (A.size1 != A.size2) {
	    throw new ArgumentException("Matrix must be square!");
	}
	matrix invA = new matrix(A.size1, A.size1);
	vector ei = new vector(A.size1);
	vector xi = new vector(A.size1);
	for (int i=0; i<A.size1; i++) {
	    for (int j=0; j<A.size1; j++) {
		ei[j] = 0;
		if (i==j) ei[j] = 1;
	    }
	    xi = this.solver(ei);
	    for (int j=0; j<A.size1; j++) {
		invA[j, i] = xi[j];
	    }
	}
	return invA;
    } //inverse
    
    

}//bidiag
