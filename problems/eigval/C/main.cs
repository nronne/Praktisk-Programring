using static System.Console;
using System;

class main {
    static void Main(string[] args) {
	int n = int.Parse(args[0]);
	randomTest(n);
    }

    static void randomTest(int n) {
	matrix a = randomSymmetricMatrix(n);
	Write("Random symmetric matrix A given as:\n");
       	a.print("A=");
	
	diagJacobi testClassic = new diagJacobi(a, classic:true);
	
	testClassic.l.print("eigenvalues found from classic jacobi algorithm: ");
	Write($"found with {testClassic.rotations} rotations.\n");
	
	diagJacobi test = new diagJacobi(a);
	test.l.print("Eigenvalues found from algorith with cyclic sweep: ");
	Write($"found with {test.rotations} rotations.\n");
	
    }//randomTest

    static matrix randomSymmetricMatrix(int n) {
	matrix mat = new matrix(n, n);
	Random rnd = new Random();
	for (int j = 0; j<n; j++) {
	    for (int i = 0; i<=j; i++) {
		double aij = 10*rnd.NextDouble();
		mat[i,j] = aij;
		mat[j,i] = aij;
	    }
	}
	return mat;
    }//randomMatrix
}//mainB
