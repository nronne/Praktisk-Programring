using static System.Console;
using static System.Math;
using System.IO;

static class main{
    static void Main(string[] args){
        var gamma_out = args[0];
        StreamWriter gammaWriter = new StreamWriter(gamma_out);
        double eps=1.0/32, dx=1.0/16;
        for(double x=-3+eps; x<=3; x+=dx){
            Write($"{x,10:f3} {myFun.erf(x),15:f10}\n");
        }
       for(double x=-4+eps; x<=6; x+=dx){
           gammaWriter.Write($"{x,10:f3} {myFun.gamma(x),15:f10}\n");
       }
       gammaWriter.Close();
}//Main
}//main
