using System;
using static System.Console;
using static System.Math;
class main{
delegate double myfun(double x);

static Func<double,double> makefun(double y)
{// makefun returns a function of the type "double delegate(double x)"
	double a=y;
	Func<double,double> f = delegate(double x){return a;};// unused variable
	Func<double,double> g = (x) => a; // equivalent lambda expression
	return g;
}

static double eval(Func<double,double> f, double x)
{// takes a function as first argument
	return f(x);
}

static int ncalls;
const double inf=System.Double.PositiveInfinity;
static double gamma(double z){
	if(z<0) return -PI/Sin(PI*z)/gamma(1+z);
	if(z<1) return gamma(z+1)/z;
	if(z>2) return gamma(z-1)*(z-1);
	Func<double,double> f= delegate(double x){
		ncalls++;
		return Pow(x,z-1)*Exp(-x);
		};
	ncalls=0;
	return quad.o8av(f,0,inf,acc:1e-6,eps:0);
	}

static double gamma4(double z){
	const double inf=System.Double.PositiveInfinity;
	if(z<0) return -PI/Sin(PI*z)/gamma4(1+z);
	if(z<1) return gamma4(z+1)/z;
	if(z>2) return gamma4(z-1)*(z-1);
	Func<double,double> f= delegate(double x){
		ncalls++;
		return Pow(x,z-1)*Exp(-x);
		};
	ncalls=0;
	return quad.o4av(f,0,inf,acc:1e-6,eps:0);
	}

static int Main(){
	double a;
	a=1;
	Func<double,double> h1 = (x)=>a;
	a=2;
	Func<double,double> h2 = (x)=>a;
	a=9;
	Error.Write($"a={a}, h1(0)={eval(h1,0)}, h2(0)={eval(h2,0)}\n");

	var f1 = makefun(1);
	var f2 = makefun(2);
	Error.Write($"f1(0)={f1(0)}, f2(0)={f2(0)}\n");

	for(double x=0.5;x<9;x+=0.5)
Write($"{x:f5} {gamma(x):f10} {ncalls} {gamma4(x):f10} {ncalls}\n");
return 0;
}
}
