using System;
using static System.Console;
using System.IO;

class main {
    public static void Main() {	
	Write("==== B ====\n");
	Write("Testing inverse by Gram-Schmidt in random matrix A:\n");
	matrix a = rndMat.randomMatrix(5, 5);
	a.print("A = ");
	var qr = new qrDecompositionGS(a);

	Write("Inverse is found to be:\n");
	(qr.inverse()).print("A^(-1) = ");
	Write("Checking that this is indeed the desired inverse matrix by calculating I=A^-1 * A:\n");
	(qr.inverse()*a).print("A^(-1)*A = ");

    } //Main
} //main
