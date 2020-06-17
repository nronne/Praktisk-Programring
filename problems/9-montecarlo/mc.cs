using System;
using static System.Math;
using static System.Console;

public class mc {
    public static double[] plainmc(Func<vector, double> f, vector start, vector end, int N) {
	Random rnd = new Random();
	Func<vector, vector, vector> randomx = delegate(vector a, vector b) {
	    vector x = new vector(a.size);
	    for (int i=0; i< x.size; i++) {
		double r = rnd.NextDouble();
		x[i] = a[i]+r*(b[i]- a[i]);
	    }
	    return x;
	};
	double volume = 1;
	for (int i = 0; i<start.size; i++) {
	    volume *= end[i]-start[i];
	}
	double sum = 0;
	double squaresum = 0;
	for (int i = 0; i<N; i++) {
	    double fx = f(randomx(start, end));
	    sum += fx;
	    squaresum += fx*fx;
	}
	double mean = sum/N;
	double sigma = Sqrt(squaresum/N-mean*mean)/Sqrt(N);
	return new double[] {volume*mean, volume*sigma };
    }
}
