using System;
using static System.Console;
using static System.Math;

public class cSpline {
    vector x, y, b, c, d, dxs;
    public cSpline(vector xs, vector ys) {
	x = xs;
	y = ys;
	int n = x.size;
	vector p = new vector(n-1);
	b = new vector(n);
	c = new vector(n-1);
	d = new vector(n-1);
	dxs = new vector(n-1);
	
	if (ascendingOrder(x) != true) {
	    throw new ArgumentException("Vector x is NOT in ascending order!");
	}//Exception
	
	double dx, dy;
	for (int i=0; i<n-1; i++) {
	    dx = x[i+1]-x[i];
	    dxs[i] = dx;
	    dy = y[i+1]-y[i];
	    p[i]=dy/dx;
	}//linear coefficients p
	
	vector D, Q, B; // tridiagonal system
	D = new vector(n);
	Q = new vector(n-1);
	B = new vector(n);
	D[0] = 2; 
	for(int i=1; i<n-1; i++) {
	    D[i] = 2*dxs[i-1]/dxs[i] + 2;
	} // diagonal values
	D[n-1] = 2;
	
	Q[0] = 1; 
	for(int i=1; i<n-1; i++) {
	    Q[i] = dxs[i-1]/dxs[i];
	}// above-diagonal values
	
	B[0] = 3*p[0];
	B[n-1] = 3*p[n-2];
	for(int i=1; i<n-1; i++) {
	    B[i] = 3*(p[i-1] + p[i]*dxs[i-1]/dxs[i]);
	} // right-hand-side values
	
	for(int i=1; i<n; i++) {
	    D[i]-=Q[i-1]/D[i-1];
	    B[i]-=B[i-1]/D[i-1];
	} // Gauss elimination
	
	b[n-1] = B[n-1]/D[n-1];
	for(int i=n-2; i>=0; i--) {
	    b[i] = (B[i]-Q[i]*b[i+1])/D[i];
	} // back substitution

	for(int i=0; i<n-1; i++) {
	    c[i] = (-2*b[i] - b[i+1] + 3*p[i])/dxs[i];
	    d[i] = (b[i]+b[i+1] - 2*p[i])/(dxs[i]*dxs[i]);
	} // setting coefficients

    }//Constructor

    public double spline(double z) {
	if (z < x[0] || z > x[x.size-1]) {
	    throw new ArgumentException("double z is not between first and last x-value");
	}//Exception
	
	int i = Search.binary(x, z);
	return y[i]+(z-x[i])*(b[i]+(z-x[i])*(c[i]+d[i]*(z-x[i])));
    }//spline method
    
    public double integral(double z) {
    	int i = Search.binary(x, z);
    	double r = 0;
    	for (int j=0; j<i; j++) {
    	    r += y[j]*dxs[j]+0.5*b[j]*dxs[j]*dxs[j] + c[j]*dxs[j]*dxs[j]*dxs[j]/3 + d[j]*dxs[j]*dxs[j]*dxs[j]*dxs[j]/4;
    	}
    	r += y[i]*(z-x[i]) + 0.5*b[i]*(z-x[i])*(z-x[i]) + c[i]*(z-x[i])*(z-x[i])*(z-x[i])/3 + d[i]*(z-x[i])*(z-x[i])*(z-x[i])*(z-x[i])/4;
    	return r;
    }//integral

    public double derivative(double z) {
    	int i = Search.binary(x, z);
    	return b[i] + z*((z-x[i])*(2*c[i] + 3*d[i]*(z-x[i])));
    }//derivative

    static bool ascendingOrder(vector x) {
	bool r = true;
	for (int j=0; j<(x.size-1); j++) {
	    if (x[j] >= x[j+1]) {
		r=false;
	    }
	}
	return r;
    }//acendingOrder
}//cSpline


public class qSpline {
    vector x, y, p, c, dxs;
    public qSpline(vector xs, vector ys) {
	x = xs;
	y = ys;
	p = new vector(x.size-1);
	c = new vector(x.size-1);
	dxs = new vector(x.size-1);
	
	if (ascendingOrder(x) != true) {
	    throw new ArgumentException("Vector x is NOT in ascending order!");
	}//Exception
	
	double dx, dy;
	for (int i=1; i<x.size; i++) {
	    dx = x[i]-x[i-1];
	    dxs[i-1] = dx;
	    dy = y[i]-y[i-1];
	    p[i-1]=dy/dx;
	}//linear coefficients p
	
	c[0] = 0;
	for(int i=1;i<x.size-1; i++) {
	    c[i] = (p[i] - p[i-1] - c[i-1]*dxs[i-1])/dxs[i];
	}//forward recurssion for quadratic coefficients c.
	
	c[x.size-2] = c[x.size-2]/2;
	for (int i=x.size-2; i>0; i--) {
	    c[i-1] = (p[i]-p[i-1]-c[i]*dxs[i])/dxs[i-1];
	}//backward recurssion for quadratic coefficients c.	
    }//Constructor

    public double spline(double z) {
	if (z < x[0] || z > x[x.size-1]) {
	    throw new ArgumentException("double z is not between first and last x-value");
	}//Exception
	
	int i = Search.binary(x, z);
	return y[i]+(p[i]-c[i]*dxs[i])*(z-x[i])+c[i]*(z-x[i])*(z-x[i]);
    }//spline method


    public double integral(double z) {
    	int i = Search.binary(x, z);
    	double r = 0;
    	for (int j=0; j<i; j++) {
    	    r += y[j]*dxs[j]+0.5*(p[j]-c[j]*dxs[j])*dxs[j]*dxs[j] + c[j]*dxs[j]*dxs[j]*dxs[j]/3;
    	}
    	r += y[i]*(z-x[i]) + 0.5*(p[i]-c[i]*dxs[i])*(z-x[i])*(z-x[i]) + c[i]*(z-x[i])*(z-x[i])*(z-x[i])/3;
    	return r;
    }//integral

    public double derivative(double z) {
	int i = Search.binary(x, z);
	return (p[i]-c[i]*dxs[i]) + 2*c[i]*z*(z-dxs[i]);
    }//derivative

    
    static bool ascendingOrder(vector x) {
	bool r = true;
	for (int j=0; j<(x.size-1); j++) {
	    if (x[j] >= x[j+1]) {
		r=false;
	    }
	}
	return r;
    }//acendingOrder
}//qSpline class

public class lSpline {
    vector x, y, b, dxs;
    public lSpline(vector xs, vector ys) {
	x = xs;
	y = ys;
	b = new vector(x.size-1);
	dxs = new vector(x.size-1);
	if (ascendingOrder(x) != true) {
	    throw new ArgumentException("Vector x is NOT in ascending order!");
	}
	double dx, dy;
	for (int i=1; i<x.size; i++) {
	    dx = x[i]-x[i-1];
	    dxs[i-1] = dx;
	    dy = y[i]-y[i-1];
	    b[i-1]=dy/dx;
	}
	
    }//Constructor

    public double spline(double z) {
	if (z < x[0] || z > x[x.size-1]) {
	    throw new ArgumentException("double z is not between first and last x-value");
	}
	int i = Search.binary(x, z);
	return y[i]+b[i]*(z-x[i]);
    }//spline

    public double integral(double z) {
	int i = Search.binary(x, z);
	double r = 0;
	for (int j=0; j<i; j++) {
	    r += y[j]*dxs[j]+0.5*b[j]*dxs[j]*dxs[j];
	}
	r += y[i]*(z-x[i]) + 0.5*b[i]*(z-x[i])*(z-x[i]);
	return r;
    }
    
    static bool ascendingOrder(vector x) {
	bool r = true;
	for (int j=0; j<(x.size-1); j++) {
	    if (x[j] >= x[j+1]) {
		r=false;
	    }
	}
	return r;
    }//acendingOrder
}//lSpline
    
public class Search{
    public static int binary(vector x, double z) {
	int r = -1;
	int left = 0;
	int right = x.size-1;
	while (left < right) {
	    int mid = (int) Floor((left+right)/2.0);
	    if (z < x[mid]) {
		right = mid;
	    }
	    else if (z > x[mid+1]) {
		left = mid+1;
	    }
	    else {
		r =  mid;
		break;
	    }
	}
	return r;	
	}//binary   
}//Seach


public static class Test {
    public static void binarySearchTest(){
	double[] a = {0.2, 0.7, 1.4, 1.9, 2.6, 3.4, 7.6, 8.0};
	vector t = new vector(a);
	bool testConfirm = true;
	if (Search.binary(t, 0.5) != 0) testConfirm = false;
	if (Search.binary(t, 1.2) != 1) testConfirm = false;
	if (Search.binary(t, 1.5) != 2) testConfirm = false;
	if (Search.binary(t, 2.5) != 3) testConfirm = false;
	if (Search.binary(t, 3.0) != 4) testConfirm = false;
	if (Search.binary(t, 3.5) != 5) testConfirm = false;
	if (Search.binary(t, 7.9) != 6) testConfirm = false;	
	if (testConfirm) Write("binarySearch test confirmed!\n");
	else Write("Test not confirmed! Error in binary search.\n");
    }//binarySearchTest
}//test
  
