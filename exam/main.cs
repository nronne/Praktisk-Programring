using System;
using static System.Math;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	matrix A = rndMat.randomMatrix(5, 3);
	Write("Example of Golub-Kahan-Lanczos bidiagonalization on tall matrix:\n");
	A.print("A =");
	var gkl = new bidiag(A);
	gkl.U.print("\n U = ");
	gkl.V.print("\n V = ");

	matrix B_calc = gkl.U.transpose() * A * gkl.V;
	B_calc.print("\n U^T*A*V = ");
	gkl.B.print("\n B = ");

	(A-gkl.U*gkl.B*gkl.V.transpose()).print("\n 0 = A - U*B*V^T =");

	Write("\n Use bidiagonalization to solve Ax=b equation:\n");
	A = new matrix("1,1,1;0,2,5;2,5,-1");
	A.print("A");
	vector b = new vector("6,-4,27");
	b.print("b=");
	gkl = new bidiag(A);
	gkl.solver(b).print("x=");
	Write($"|Det(A)| = {gkl.determinant()}\n");
	gkl.inverse().print("A^-1 = ");
	(gkl.inverse()*A).print("A^-1 * A = ");

	int success = 0;
	double eps = 1e-8;
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
