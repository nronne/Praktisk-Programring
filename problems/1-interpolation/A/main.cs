using static System.Console;
using static System.Math;
using System.IO;

static class main {
    static void Main() {
	// Test.binarySearchTest();
	int n = 15;
	vector xs = new vector(n);
	vector ys = new vector(n);
	StreamWriter val = new StreamWriter("sin_values.txt");
	StreamWriter lSplineWriter = new StreamWriter("sin_lspline.txt");
	for(int i = 0; i<n; i++) {
	    xs[i] = i/2.0;
	    ys[i] = Sin(xs[i]);
	    val.Write($"{xs[i],5:f8} {ys[i],10:f12}\n");
	}
	lSpline sinLinSpline = new lSpline(xs, ys);
	for (double x=0; x<7; x+=0.05) {
	    lSplineWriter.Write($"{x,10:f8} {sinLinSpline.spline(x),15:f16}\n");
	}
	
	Write($"Integral from 0 to pi of sin(x) with linear spline: {sinLinSpline.integral(PI)}\n");
	Write("True value of integral is 2.\n");
	val.Close();
	lSplineWriter.Close();

       	
    }//Main
}//main
