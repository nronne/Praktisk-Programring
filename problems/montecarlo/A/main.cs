using System;
using static System.Math;
using static System.Console;

class main {
    public static void Main() {
	Write("____ Test _____\n");
	double[] result = pi(10000);
	if(Abs(result[0]-PI) < result[1]) {
	    Write("Test passed!\n");
	}
	
	Write("\n____ integral exercise _____ \n");
	Func<vector, double> f = delegate(vector x) {
	    double r = 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))/( PI*PI*PI);
	    return r;
	};
	vector a = new vector(0, 0, 0);
	vector b = new vector (PI, PI, PI);
	int N = 1000000;
	result = mc.plainmc(f, a, b, N);
	Write($"value {result[0]} with error {result[1]}\n");
	
    }
    
    public static double[] pi(int N) {
	Func<vector, double> f = delegate(vector x) {
	    double r = 0;
	    if(x[0]*x[0]+x[1]*x[1] <= 1) r=1;
	    return r;
	};
	vector a = new vector(-1, -1);
	vector b = new vector (1, 1);
	double[] result = mc.plainmc(f, a, b, N);
	Write($"value {result[0]} with error {result[1]}\n");
	return result;

    }
}
