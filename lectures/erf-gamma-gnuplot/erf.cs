using System;
using static System.Math;
public static partial class math{

public static double erf(double x){
/// single precision error function (Abramowitz and Stegun)
	if(x<0) return -erf(-x);
	double[] a =
	{0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
	double t=1/(1+0.3275911*x);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
	return 1.0-sum*Exp(-x*x);
}

public static int ncalls;

public static double erf2(double x){
if(x<0) return -erf2(-x);
if(x>2.5) return 1-erf2c(x);
ncalls=0;
Func<double,double> f = delegate(double t){ncalls++;return Exp(-t*t);};
double integ = quad.o8a(f,0,x,acc:1e-9,eps:0);
System.Console.Error.WriteLine($"x={x} ncalls={ncalls}");
return 2/Sqrt(PI)*integ;
}

const double inf=double.PositiveInfinity;
public static double erf2c(double x){
if(x<0) return 2-erf2c(-x);
if(x<=2.5) return 1-erf2(x);
ncalls=0;
Func<double,double> f = delegate(double t){ncalls++;return Exp(-t*t);};
double integ=quad.o8av(f,x,inf,acc:1e-9,eps:0);
System.Console.Error.WriteLine($"x={x} ncalls={ncalls}");
return 2/Sqrt(PI)*integ;
}

}//math
