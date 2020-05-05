using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	vector c = new vector("1 1");
	int n=c.size;
	matrix A = new matrix(n,n);
	var rnd=new System.Random(1);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)A[i,j]=2*(rnd.NextDouble()-0.5);
	int ncalls=0;
	Func<vector,double> f;

	f = (z)=>{
		ncalls++;
		vector q=(A*(z-c)).map(t=>t*t);
		return Sqrt(q%q);
		};

	double eps;
	vector p;
	int nsteps;

	ncalls=0;
	f=(z)=>{ncalls++; return Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);};
	eps=1e-4;
	p = new vector("3 3");
	Write("qnewton.sr1: Rosenbrock's valley function\n");
	p.print("start point:");
	nsteps = qnewton.sr1(f,ref p,eps);
	Write($"nsteps={nsteps} ");
	WriteLine($"ncalls={ncalls}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f(p)}\n");
	vector g=qnewton.gradient(f,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");

	f=(z)=>Pow(z[0]*z[0]+z[1]-11,2)+Pow(z[0]+z[1]*z[1]-7,2);
	eps=1e-4;
	p = new vector("5 3");
	Write("\nqnewton.SR1: Himmelblau's function\n");
	p.print("start point:");
	nsteps = qnewton.sr1(f,ref p,eps);
	WriteLine($"nsteps={nsteps}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f(p)}\n");
	g=qnewton.gradient(f,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");

	ncalls=0;
	f=(z)=>{ncalls++; return Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);};
	double dx=1e-3;
	p = new vector("3 3");
	Write("\nsimplex.downhill: Rosenbrock's valley function\n");
	p.print("start point:");
	double psize = simplex.downhill(f,ref p,dx:dx);
	WriteLine($"simplex size ={(float)psize}");
	WriteLine($"ncalls = {ncalls}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f(p)}\n");

}
}
