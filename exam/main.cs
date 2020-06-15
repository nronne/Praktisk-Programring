using System;
using static System.Math;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	matrix A = rndMat.randomMatrix(5, 3);
	Write("Example of Golub-Kahan-Lanczos bidiagonalization on tall matrix:\n");
	Write("The matrix A is written as A = UBV^T. Example for random A given as:\n");
	A.print("A =");
	var gkl = new bidiag(A);
	Write("The found matrix U and V are: \n");
	gkl.U.print("\n U = ");
	gkl.V.print("\n V = ");

	matrix B_calc = gkl.U.transpose() * A * gkl.V;
	Write("The bidiogonal matrix calculated via U and V, and directly from the method is given below: \n");
	B_calc.print("\n U^T * A * V = ");
	gkl.B.print("\n B = ");

	Write("The difference between A and the representation of A through B:\n");
	(A-gkl.U*gkl.B*gkl.V.transpose()).print("\n 0 = A - U*B*V^T =");

	Write("\n Use bidiagonalization to solve Ax=b equation for square random matrix matrix A:\n");
	A = rndMat.randomMatrix(3,3);
	A.print("A = ");
	Write("With random vector b:\n");
	vector b = rndMat.randomVector(3);
	b.print("b =");
	gkl = new bidiag(A);
	vector x = gkl.solver(b);
	Write("Solution to equation:\n");
	x.print("x =");
	vector diff = A*x-b;
	Write("Check if solution is correct: \n");
	diff.print("0 = A*x - b =");
	

	Write("\n Determinant (found as product of diagonal of B) and inverse:\n");
	Write($"|Det(A)| = {gkl.determinant()}\n");
	gkl.inverse().print("A^-1 = ");
	Write("Check if inverse is correct: \n");
	(gkl.inverse()*A).print("1 = A^-1 * A = ");

	int success = 0;
	double eps = 1e-7; 
	success = tests.differenceTest(eps);
	success += tests.solverTest(eps);
	success += tests.inverseTest(eps);

	Write("\n ===== Tests result =====\n");
	if(success == 0) {
	    Write("All test PASSED! \n");
	}
	else {
	    Write("One or several test FAILED! \n");
	}

		
	
    } //Main
} //main
