using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	Write("----------(A.1)-----------\n");
	matrix a = rndMat.randomMatrix(5, 3);
	a.print("A =");
	qrDecompositionGS qr = new qrDecompositionGS(a);
	(qr.q).print("Q = ");;
	(qr.r).print("R = ");;
	(qr.q.transpose() * qr.q).print("Q^T*Q = ");
	(a-qr.q*qr.r).print("A-QR = ");

	
	Write("----------(A.2)-----------\n");
	a = rndMat.randomMatrix(5, 5);
	a.print("A = ");
	qr = new qrDecompositionGS(a);
	vector b = rndMat.randomVector(5);
	b.print("b = ");
	vector x = qr.solve(b);
	x.print("x = ");
	//(a*x-b).print("A*x-b = ");
    } //Main

    
} //main
