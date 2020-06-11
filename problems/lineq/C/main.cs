using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {
	Write("----------(C)-----------\n");
	matrix a = rndMat.randomMatrix(5, 5);
	var qr = new qrDecompositionGS(a);
	vector b = rndMat.randomVector(5);
	//a = new matrix("6,5,0;5,1,4;0,4,3");
	a.print("A = ");
	b.print("b = ");
	qrDecompositionGivens qrGivens = new qrDecompositionGivens(a);
	qrGivens.qr.print("R = ");
	var x = qrGivens.solve(b);
	x.print("x = ");
	//(a*x-b).print("A*x-b = ");
    } //Main
} //main
