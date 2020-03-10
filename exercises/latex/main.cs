using static System.Console;
using System.IO;
static class main{
    static void Main(){
        for(double x=0.0; x<=14; x+=0.03125){
            Write($"{x,10:f8} {bessel.Bessel(x, n:0),15:f16} {bessel.Bessel(x, n:1),15:f16} {bessel.Bessel(x, n:2),15:f16} \n");
	}
    }//Main
}//main
