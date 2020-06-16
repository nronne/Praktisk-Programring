using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	Write("==== A.1 ====\n");
	Write("Testing on random tall matrix A:\n");
	matrix a = rndMat.randomMatrix(5, 3);
	a.print("A =");
	qrDecompositionGS qr = new qrDecompositionGS(a);
	Write("Q and R matrices found from QR-factorization:\n");
	(qr.q).print("Q = ");;
	(qr.r).print("R = ");;
	Write("Testing that Q is orthogonal:\n");
	(qr.q.transpose() * qr.q).print("Q^T*Q = ");
	Write("Calculating the difference between A and QR, which should be 0:\n");
	(a-qr.q*qr.r).print("A-QR = ");

	
	Write("\n==== A.2 ====\n");
	Write("Testing solver on random matrix A:\n");
	a = rndMat.randomMatrix(5, 5);
	a.print("A = ");
	qr = new qrDecompositionGS(a);
	Write("and random vector b:\n");
	vector b = rndMat.randomVector(5);
	b.print("b = ");
	Write("Solution to Ax=b is found to be:\n");
	vector x = qr.solve(b);
	x.print("x = ");
	Write("Checking that x is a solution by calculating 0=Ax-b:\n");
	vector diff = a*x-b;
	diff.print("A*x-b = ");
    } //Main

    
} //main
