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
	val.Close();
	lSplineWriter.Close();

	StreamWriter qSplineWriter = new StreamWriter("sin_qspline.txt");
	qSpline sinQuaSpline = new qSpline(xs, ys);
	for (double x=0; x<7; x+=0.05) {
	    qSplineWriter.Write($"{x,10:f8} {sinQuaSpline.spline(x),15:f16}\n");
	}
	qSplineWriter.Close();
	Write($"Integral from 0 to pi of sin(x) with quadratic spline: {sinQuaSpline.integral(PI)}\n");
	Write("True result from analytic expression is: 2.00\n");

	Write($"Derivative of sin(x) evaluated at pi/4: {sinQuaSpline.derivative(PI/4)}\n");
	Write("True result from analytic expression is: 1/sqrt(2) or 0.707106781186547 \n");

	StreamWriter cSplineWriter = new StreamWriter("sin_cspline.txt");
	cSpline sinCubSpline = new cSpline(xs, ys);
	for (double x=0; x<7; x+=0.05) {
	    cSplineWriter.Write($"{x,10:f8} {sinCubSpline.spline(x),15:f16}\n");
	}
	cSplineWriter.Close();
	
	Write($"Integral from 0 to pi of sin(x) with cubic spline: {sinCubSpline.integral(PI)}\n");
	Write("True result from analytic expression is: 2.00\n");

	Write($"Derivative of sin(x) evaluated at pi/4: {sinCubSpline.derivative(PI/4)}\n");
	Write("True result from analytic expression is: 1/sqrt(2) or 0.707106781186547 \n");
	
    }//Main
}//main
