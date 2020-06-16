using System;
using static System.Math;
using static System.Console;

static class main{
    static void Main(){
        // 1.
        Func<double, double> f = (x) => (Log(x)/Sqrt(x));
        double a=0.0, b=1.0, result;
        result = quad.o8av(f, a, b);
        Write($"integral of ln(x)/sqrt(x) is {result}\n");
        // 2.
        double posInf = double.PositiveInfinity;
        double negInf = double.NegativeInfinity;
        f = (x) => Exp(-x*x);
        result = quad.o8av(f, negInf, posInf);
        Write($"integral of exp(-x^2) is {result}\n");
        Write("Note: sqrt(pi) = {0}\n", Sqrt(PI));
        // 3.
	
        for(double p=3.0; p<6; p+=1.0){
	    f = (x) => Pow(Log(1/x), p);
	    result = quad.o8av(f, a, b);
	    Write($"integral of ln(1/x)^{p} is {result}\n");
	}
    }//Main
}//main
