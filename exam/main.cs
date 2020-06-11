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
	
	if(differenceTest(1e-8) == 0) {
	    Write("All test PASSED! \n");
	}
	else {
	    Write("One or several test FAILED! \n");
	}

		
	
    } //Main

    static int differenceTest(double eps) {
	Write("\n ===== Difference Test =====\n");
	Write("Performed by calculating the difference: A - U*B*V^T = 0. \n");
	
	int successSquare = 0;
	for(int i=2; i<6; i++){
	    matrix A = rndMat.randomMatrix(i, i);
	    var gkl = new bidiag(A);
	    matrix diff = A-gkl.U*gkl.B*gkl.V.transpose();
	    for(int m=0; m<i;m++){
		for(int n=0; n<i; n++){
		    if(Abs(diff[m,n])>eps) {
			successSquare = 1;
		    }
		}
	    }
	}
	if(successSquare == 0) {
	    Write("Square matrix difference test PASSED!\n");
	}
	else {
	    Write("Square matrix difference test FAILED!\n");
	}
	
	
	int successTall = 0;
	for(int i=3; i<6; i++){
	    for(int j=2; j<i; j++) {
		matrix A = rndMat.randomMatrix(i,j);
		var gkl = new bidiag(A);
		matrix diff = A-gkl.U*gkl.B*gkl.V.transpose();
		for(int m=0; m<i;m++){
		    for(int n=0; n<j; n++){
			if(Abs(diff[m,n])>eps) {
			    successTall = 1;
			}
		    }
		}
	    }
	}
	if(successTall == 0) {
	    Write("Tall matrix difference test PASSED!\n");
	}
	else {
	    Write("Tall matrix difference test FAILED!\n");
	}
	
	return successSquare + successTall;   
    }
} //main
