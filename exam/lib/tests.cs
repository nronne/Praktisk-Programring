using System;
using static System.Math;
using static System.Console;

public class tests {
    public static int solverTest(double eps){
	int success = 0;
	Write("\n ===== Solver Test =====\n");
	Write("Performed by calculating the difference: Ax - b = 0. \n");
	
	for(int i=2; i<6; i++){
	    matrix A = rndMat.randomMatrix(i, i);
	    vector b = rndMat.randomVector(i);
	    var gkl = new bidiag(A);
	    vector diff = A*gkl.solver(b)-b;
	    for(int m=0; m<i;m++){
		if(Abs(diff[m])>eps) {
			success = 1;
		}
	    }
	}

	if(success == 0) {
	    Write("Solver test PASSED!\n");
	}
	else {
	    Write("Solver test FAILED!\n");
	}
	return success;
    }//solverTest


    public static int inverseTest(double eps) {
	int success = 0;
	Write("\n ===== Inverse Test =====\n");
	Write("Performed by calculating the difference: A*A^-1 - I = 0. \n");
	
	for(int i=2; i<6; i++){
	    matrix A = rndMat.randomMatrix(i, i);
	    matrix I = new matrix(i,i);
	    I.set_identity();
	    var gkl = new bidiag(A);
	    matrix diff = A*gkl.inverse()-I;
	    for(int m=0; m<i;m++){
		for(int n=0; n<i; n++){
		    if(Abs(diff[m,n])>eps) {
			success = 1;
		    }
		}
	    }
	}
	if(success == 0) {
	    Write("Inverse test PASSED!\n");
	}
	else {
	    Write("Inverse test FAILED!\n");
	}

	return success;
	
    }//inverseTest
    
    public static int differenceTest(double eps) {
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
    }//differenceTest
}//tests
