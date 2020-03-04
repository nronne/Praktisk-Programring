using static System.Math;
using static System.Console;
class main{
const double inf=double.PositiveInfinity;
static int Main(){

int ncalls=0,ierr=0;
double q,exact,acc,eps;
System.Func<double,double> f;

acc=1e-6; eps=0; exact = 2.0/5*(1-Exp(-PI));
WriteLine($"c5a: testing int_0^PI Exp(-x)Sin(x)^2dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Exp(-x)*Sin(x)*Sin(x);};
ncalls=0; q=quad.c5a(f,0,PI,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 2.0/5*(1-Exp(-PI));
WriteLine($"c7a: testing int_0^PI Exp(-x)Sin(x)^2dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Exp(-x)*Sin(x)*Sin(x);};
ncalls=0; q=quad.c7a(f,0,PI,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 2.0/5*(1-Exp(-PI));
WriteLine($"o8a: testing int_0^PI Exp(-x)Sin(x)^2dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Exp(-x)*Sin(x)*Sin(x);};
ncalls=0; q=quad.o8a(f,0,PI,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

	acc=1e-6; eps=0; exact = Sqrt(PI);
WriteLine($"o8av: testing int_-inf^inf exp(-x^2)dx={exact},acc={acc},eps={eps}");
	f = delegate(double x){ ncalls++; return Exp(-x*x);};
	ncalls=0; q=quad.o8av(f,-inf,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-6; eps=0; exact = Sqrt(PI)/2;
WriteLine($"o8av: testing int_0^inf exp(-x^2)dx={exact},acc={acc},eps={eps}");
	f = delegate(double x){ ncalls++; return Exp(-x*x);};
	ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-6; eps=0; exact = 2;
WriteLine($"o4acc: testing int_0^1 1/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return 1/Sqrt(x);};
	ncalls=0; q=quad.o4acc(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-6; eps=0; exact = 2;
WriteLine($"o4av: testing int_0^1 1/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return 1/Sqrt(x);};
	ncalls=0; q=quad.o4av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-6; eps=0; exact = 2;
WriteLine($"o8av: testing int_0^1 1/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return 1/Sqrt(x);};
	ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-5; eps=0; exact = -4;
WriteLine($"o4acc: int_0^1 Log(x)/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return Log(x)/Sqrt(x);};
	ncalls=0; q=quad.o4acc(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-9; eps=0; exact = -4;
WriteLine($"o4av: int_0^1 Log(x)/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return Log(x)/Sqrt(x);};
	ncalls=0; q=quad.o4av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

	acc=1e-9; eps=0; exact = -4;
WriteLine($"o8av: int_0^1 Log(x)/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
	f = delegate(double x){ ncalls++; return Log(x)/Sqrt(x);};
	ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
	if(math.approx(q,exact,acc,eps))WriteLine("test passed\n");
	else {ierr++;WriteLine("test failed\n");}

WriteLine($"failed tests: {ierr}");
return ierr;
}
}
