using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	Write("----------(A.1)-----------\n");
	matrix a = randomMatrix(5, 3);
	a.print("A =");
	qrDecompositionGS qr = new qrDecompositionGS(a);
	(qr.q).print("Q = ");;
	(qr.r).print("R = ");;
	(qr.q.transpose() * qr.q).print("Q^T*Q = ");
	(a-qr.q*qr.r).print("A-QR = ");

	
	Write("----------(A.2)-----------\n");
	a = randomMatrix(4, 4);
	a.print("A = ");
	qr = new qrDecompositionGS(a);
	vector b = randomVector(4);
	b.print("b = ");
	vector x = qr.solve(b);
	x.print("x = ");
	(a*x-b).print("A*x-b = ");


	Write("----------(B)-----------\n");
	a.print("A = ");
	(qr.inverse()).print("A^(-1) = ");
	(qr.inverse()*a).print("A^(-1)*A = ");

	
	Write("----------(C)-----------\n");
	//a = new matrix("6,5,0;5,1,4;0,4,3");
	a.print("A = ");
	b.print("b = ");
	qrDecompositionGivens qrGivens = new qrDecompositionGivens(a);
	qrGivens.qr.print("R = ");
	x = qrGivens.solve(b);
	x.print("x = ");
	(a*x-b).print("A*x-b = ");
    } //Main

    
    static matrix randomMatrix(int n, int m) {
	matrix mat = new matrix(n, m);
	Random rnd = new Random();
	for (int i = 0; i<n; i++) {
	    for (int j = 0; j < m; j++) {
		mat[i,j] = 10*rnd.NextDouble();
	    }
	}
	return mat;
    } // randomMatrix

    static vector randomVector(int n) {
	vector vec = new vector(n);
	Random rnd = new Random();
	for (int i = 0; i<n; i++) {
	    vec[i] = 10 * rnd.NextDouble();
	}
	return vec;
    } //randomVector
} //main
