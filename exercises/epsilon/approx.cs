using static System.Math;

public class Comparison{
    public static bool Approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
	bool isSame = false;
	if (Abs(a-b) < tau){isSame = true;}
	else if (Abs(a-b)/(Abs(a)+Abs(b)) < epsilon/2) {isSame = true;}
	return isSame;
    } 
}



