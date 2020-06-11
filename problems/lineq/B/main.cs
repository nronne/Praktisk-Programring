using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {	
	Write("----------(B)-----------\n");

	matrix a = rndMat.randomMatrix(5, 5);
	a.print("A = ");
	var qr = new qrDecompositionGS(a);

	a.print("A = ");
	(qr.inverse()).print("A^(-1) = ");
	(qr.inverse()*a).print("A^(-1)*A = ");

    } //Main
} //main
