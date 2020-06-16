using static System.Console;
using System;

class mainB {
    static void Main(string[] args) {
	Write($"n={args}\n");
	int n = int.Parse(args[0]);
	randomTest(n);
    }

    static void randomTest(int n) {
	matrix a = randomSymmetricMatrix(n);
	diagJacobi test = new diagJacobi(a, eigVec:true, classic:true);
    }//randomTest

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
}//mainB
