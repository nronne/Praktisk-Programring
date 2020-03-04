using System;
using static System.Math;
using static System.Console;
using static cmath;
class main{
static void Main(){
	complex i = new complex(0,1);
	i.print("i= ");
	(i*i).print("i*i=");
	exp(i*PI).print("exp(i*PI)=");
	sin(i).print("sin(i)=");
	i.pow(i).print("i^i=");
	abs(i).print("abs(i)=");
	(arg(i)/PI).print("arg(i)/PI=");
	WriteLine("i.Re={0}, i.Im={1}",i.Re,i.Im);
}//Main
}//main
