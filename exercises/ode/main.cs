using System;
using static System.Console;
using System.Collections.Generic;
static class main{
    static void Main(){
        Func<double, vector, vector> logistic = delegate(double x, vector y){
            vector one = new vector(1.0);
            return new vector(y.dot(one-y));
        };
        double a=0.0, b=3.0;
        vector ya = new vector(0.5);
        List<double> xs = new List<double>();
        List<vector> ys = new List <vector>();
        ode.rk23(logistic,a,ya,b,xlist:xs,ylist:ys);
        for(int i=0; i<xs.Count; i++){
            Write($"{xs[i],10:f5} {ys[i][0],15:f10}\n");
        }

    }
}
