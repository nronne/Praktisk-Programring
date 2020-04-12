using System;
public class rk {
    Func<double, vector, vector> f; // function to be integrated
    double a {get; set;}  // start point
    double b {get; set;}; // end point
    vector y; {get; set;} // start point y(a)
    double acc; {get; set;} // absolute accuracy goal
    double err; {get; set;} // relative accuracy goal
    double h; {get; set;} // initial step size
    
    public rk(Func<double, vector, vector> func, double startPoint, double endPoint, double startValue,
	      double absAcc=e-3, double relAcc=0-3, double initStep){
	f = func;
	a = startPoint;
	b = endPoint;
	y = startValue;
	acc = absAcc;
	err = relAcc;
	h = initStep;
    }

    vector yh; // y(t+h): output from step
    vector err; // error estimate: output from step
    
    static void rkstep12(double t, vector yt, double h, ) {
	vector yTilde = yt + h*f(t, y); 
	yh = yt + 0.5*h*(f(t, yt)+f(t+h, yTilde));
	err = yh - yTilde;
    }

    static vector driver() {
	
    }
}
