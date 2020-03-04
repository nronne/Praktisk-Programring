using System;
using static System.Math;
public static partial class math{

public delegate double integrand (double x);

public static double integrate
(integrand f, double a, double b, double acc, double eps){
	double f2=f(a+(b-a)/3), f3=f(a+2*(b-a)/3);
	double result=adapto(f,a,b,acc,eps,f2,f3);
	//double f1=f(a), f3=f(b);
	//double result=adapt3c(f,a,b,acc,eps,f1,f3);
	//double f1=f(a), f3=((a+b)/2), f5=f(b);
	//double result=adapt5c(f,a,b,acc,eps,f1,f3,f5);
	//double h=b-a;
	//double f1=f(a), f3=(a+2*h/6), f5=f(a+4*h/6), f7=f(b);
	//double result=adapt7c(f,a,b,acc,eps,f1,f3,f5,f7);
	return result;
   }

private static double adapt
(integrand f,double a,double b,double acc,double eps,double f2,double f3){
	double h=b-a, f1=f(a+h/6), f4=f(a+5*h/6);
	double Q=(f1+f4)*h/3+(f2+f3)*h/6;
	double q=(f1+f2+f3+f4)*h/4;
	double tol=acc+eps*Abs(Q);
	double err=Abs(Q-q)/2;
	if(err<Sqrt(2)*tol){return Q;}
	else{
		double i1 = adapt(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2);
		double i2 = adapt(f,(a+b)/2,b,acc/Sqrt(2),eps,f3,f4);
		return i1+i2;
      }
}//adapt

private static double adapto
(integrand f,double a,double b,double acc,double eps,double f2,double f3){
	double h=b-a, f1=f(a+h/6), f4=f(a+5*h/6), sqr2=Sqrt(2);
	double approx1=(3*f1+4*f2      +5*f4)*h/12;
	double approx2=(5*f1      +4*f3+3*f4)*h/12;
	double integral=(approx1+approx2)/2;
	double error=Abs(approx1-approx2)/2;
	double tolerance=acc+eps*Abs(integral);
	if(error<sqr2*tolerance){return integral;}
	else{
		double i1 = adapto(f,a,(a+b)/2,acc/sqr2,eps,f1,f2);
		double i2 = adapto(f,(a+b)/2,b,acc/sqr2,eps,f3,f4);
		return i1+i2;
      }
}//adapt

private static double adapt3c
(integrand f,double a,double b,double acc,double eps,double f1,double f3){
	double h=b-a, f2=f(a+h/2);
	double Q=(f1+4*f2+f3)*h/6;
	double q=(f1+2*f2+f3)*h/4;
	double tol=acc+eps*Abs(Q);
	double err=Abs(Q-q)/2;
	if(err<Sqrt(2)*tol){return Q;}
	else{
		double i1 = adapt3c(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2);
		double i2 = adapt3c(f,(a+b)/2,b,acc/Sqrt(2),eps,f2,f3);
		return i1+i2;
      }
}//adapt

private static double adapt5c
(integrand f,double a,double b,double acc,double eps
,double f1,double f3,double f5){
	double h=b-a, f2=f(a+h/4), f4=f(a+3*h/4);
	double Q=(f1*7+f2*32+f3*12+f4*32+f5*7)*h/90;
	double q=(f1  +f2*8       +f4*8 +f5  )*h/18;
	double tol=acc+eps*Abs(Q);
	double err=Abs(Q-q)/2;
	if(err<Sqrt(2)*tol){return Q;}
	else{
		double i1 = adapt5c(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2,f3);
		double i2 = adapt5c(f,(a+b)/2,b,acc/Sqrt(2),eps,f3,f4,f5);
		return i1+i2;
      }
}//adapt

private static double adapt7c
(integrand f,double a,double b,double acc,double eps,
double f1,double f3,double f5,double f7){
	double h=b-a, f2=f(a+1*h/6), f4=f(a+3*h/6), f6=f(a+5*h/6);
	double[] w={41.0/840,9.0/35,9.0/280,34.0/105,9.0/280,9.0/35,41.0/840};
	double[] u={13.0/200,4.0/25,11.0/40,11.0/40,4.0/25,13.0/200};
	double Q=(f1*w[0]+f2*w[1]+f3*w[2]+f4*w[3]+f5*w[4]+f6*w[5]+f7*w[6])*h;
	double q=(f1*u[0]+f2*u[1]+f3*u[2]        +f5*u[3]+f6*u[4]+f7*u[5])*h;
	double tol=acc+eps*Abs(Q);
	double err=Abs(Q-q)/2;
	if(err<Sqrt(2)*tol){return Q;}
	else{
		double i1 = adapt7c(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2,f3,f4);
		double i2 = adapt7c(f,(a+b)/2,b,acc/Sqrt(2),eps,f4,f5,f6,f7);
		return i1+i2;
      }
}//adapt

}//math
