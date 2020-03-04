using static System.Math;
using static cmath;
public static partial class math{

public static double gamma(double x){
/// single precision gamma function (Gergo Nemes, from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x);
	if(x<9)return gamma(x+1)/x; // move argument up
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);
}

public static complex gamma(complex z){
/// single precision gamma function (Gergo Nemes, from Wikipedia)
	if(z.Re<0)return PI/sin(PI*z)/gamma(1-z);
	if(z.Re<9)return gamma(z+1)/z; // move argument up
	return sqrt(2*PI/z)*((z+1/(12*z-1/z/10))/E).pow(z);
}

}//math
