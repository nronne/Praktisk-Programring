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
}//bidiag
