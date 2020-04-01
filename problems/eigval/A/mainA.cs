using System;
using static System.Console;
using System.IO;
using static System.Math;

class mainA {
    static void Main(){
	randomTest(5);
	particleInBox(99);

	Write("\n \n__________________B(test)_________________\n \n");
	int firstN = 2;
	matrix A = randomSymmetricMatrix(5);
	diagJacobi firstTest = new diagJacobi(A, firstN, eigVec:true, largestFirst:false);
	(firstTest.l).print("eigenvalues (only first 2): ");
	(firstTest.v).print("eigenvectors (only first 2): ");
	diagJacobi test = new diagJacobi(A, eigVec:true);
	(test.v).print("eigenvectors correct: ");
	(test.l).print("eigenvalues correct: ");
	
    }//Main


    static matrix randomSymmetricMatrix(int n) {
	matrix mat = new matrix(n, n);
	Random rnd = new Random();
	for (int j = 0; j<n; j++) {
	    for (int i = 0; i<=j; i++) {
		double aij = 10*rnd.NextDouble();
		mat[i,j] = aij;
		mat[j,i] =aij;
	    }
	}
	return mat;
    }//randomMatrix

    static void randomTest(int n) {
	matrix a = randomSymmetricMatrix(n);
	a.print("A = ");
	diagJacobi test = new diagJacobi(a, eigVec:true);
	Write($"Number of sweeps: {test.sweeps}\n");
	(((test.v).transpose()) * a * (test.v) ).print("V^T*A*V = ");
	(test.l).print("eigenvalues = ");	
    }//randomTest

    static void particleInBox(int n) {
	StreamWriter e = new StreamWriter("box_energies.txt");
	StreamWriter psi = new StreamWriter("box_wavefun.txt");
	double s=1.0/(n+1);
	matrix H = new matrix(n,n);
	for(int i=0;i<n-1;i++){
	    matrix.set(H,i,i,-2);
	    matrix.set(H,i,i+1,1);
	    matrix.set(H,i+1,i,1);
	}
	matrix.set(H,n-1,n-1,-2);
	matrix.scale(H,-1/s/s);
	diagJacobi hamilton = new diagJacobi(H, eigVec:true);
	vector energies = hamilton.l;
	matrix wavefuncs = hamilton.v;
	for (int k=0; k < n/3; k++){
	    double exact = PI*PI*(k+1)*(k+1);
	    e.Write($"{k} {energies[k]} {exact}\n");
	}
	for(int k=0;k<3;k++){
	    psi.Write($"{0} {0}\n");
	    for(int i=0;i<n;i++) {
		psi.Write($"{(i+1.0)/(n+1)} {wavefuncs[i,k]*Sign(wavefuncs[0,k])/Sqrt(s)}\n");
	    }
	    psi.Write($"{1} {0}\n");
	}
	e.Close(); psi.Close();
	
    }
}//main
