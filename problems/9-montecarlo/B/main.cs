using System;
using static System.Math;
using static System.Console;

class main {
    public static void Main() {
	int N = 10000;
	for (int i=10; i<N; i+=10) {
	    double[] p = pi(i);
	    Write($"{i, 8} {p[0]-PI, 12:f8} {p[1]/PI, 12:f8} \n");
	}
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
	return result;

    }
}
