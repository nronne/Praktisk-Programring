using System;
using static System.Console;
using System.IO;
using static System.Math;

class mainA {
    static void Main(){
	int firstN = 2;
	matrix A = randomSymmetricMatrix(5);
	diagJacobi firstTest = new diagJacobi(A, firstN, eigVec:true, largestFirst:false);
	Write($"First 2 eigenvalues found: {firstTest.l[0]}, {firstTest.l[1]} \n");
	Write("First 2 eigenvectors found:\n");
	
	(firstTest.v[0]).print();
	(firstTest.v[1]).print();
	diagJacobi test = new diagJacobi(A, eigVec:true);
	Write("Eigenvalues and vectors from full diagonalization as comparison: \n");
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

}//main
