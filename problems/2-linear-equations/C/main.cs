using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	Write("==== C ====\n");
	Write("Checking the implementation of the Givens rotation for QR-factorization on random matrix A:\n");
	matrix a = rndMat.randomMatrix(5, 5);
	vector b = rndMat.randomVector(5);
	a.print("A = ");
	Write("Checking by solving Ax=b for random vector b:\n");
	b.print("b = ");
	qrDecompositionGivens qrGivens = new qrDecompositionGivens(a);
	vector x = qrGivens.solve(b);
	Write("The found solution x is:\n");
	x.print("x = ");
	Write("Checking the solution by calculating 0=Ax-b:\n");
	vector diff = a*x-b;
	diff.print("A*x-b = ");
			
    } //Main
} //main
