using System;
using static System.Math;
using static System.Console;

class main {
    public static void Main() {
	Write("==== Test of Monte Carlo routine ====\n\n");
	Write("Area of unit circle on square domain.\n");
	Write($"Analytic result:        pi\n");
	double[] result = pi(10000);
	Write($"Found result:           {result[0]}\n");
	Write($"Deviation:              {result[0]-PI}\n");
	Write($"Estimated error:        {result[1]}\n");
	Write($"N:                      10000\n\n");
	
	Write("==== integral exercise in exercise ===== \n\n");
  	Func<vector, double> f = delegate(vector x) {
	    double r = 1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))/( PI*PI*PI);
	    return r;
	};
	vector a = new vector(0, 0, 0);
	vector b = new vector (PI, PI, PI);
	int N = 1000000;
	result = mc.plainmc(f, a, b, N);
	Write($"Analytic result:        1.3932039296856768591842462603255\n");
	Write($"Found result:           {result[0]}\n");
	Write($"Deviation:              {result[0]-1.3932039296856768591842462603255}\n");
	Write($"Estimated error:        {result[1]}\n");
	Write($"N:                      {N}\n\n");
	
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
