using static System.Console;
using static System.Math;

public class diagJacobi {
    public vector l {get; set;} // stores eigenvalues
    public matrix a {get; set;} // strict upper triangular of a is destroyed.
    public matrix v {get; set;} // stores eigenvectors
    public int sweeps {get; set;}
    public int rotations {get; set;}
    /*
      Remember: a = v^Tav=d;
     */
    
    public diagJacobi(matrix x, bool eigVec=false, bool classic=false) {
	if (classic) {
	    this.classicJacobi(x);
	}
	else {
	    a = x.copy();
	    if (eigVec) {
		v = new matrix(a.size1, a.size1);
		v.set_identity();
	    }
	    l = new vector(a.size1);
	    for (int i=0; i<a.size1; i++) {
		l[i] = a[i,i];
	    }
	    
	    bool changed;
	    sweeps = 0;
	    rotations = 0;
	    do {
		changed = this.cyclicSweep();
		sweeps++;
	    } while(changed);
	}
    }//constructor

    public diagJacobi(matrix x, int firstN, bool eigVec=false, bool largestFirst=false) {
	a = x.copy();
	if (largestFirst) a = -1*a;
	if (eigVec) {
	    v = new matrix(a.size1, a.size1);
	    v.set_identity();
	}
	l = new vector(a.size1);
	for (int i=0; i<a.size1; i++) {
	    l[i] = a[i,i];
	}
	bool changed;
	sweeps = 0;
	rotations = 0;
	for (int r=0; r<firstN; r++) {
	    do {
		changed = this.rowSweep(r);
		sweeps++;
	    } while(changed);    
	}
	if (largestFirst) {
	    a = -1*a;
	    l = -1*l;
	}
    }//constructor


    void classicJacobi(matrix x) {
	a = x.copy();
	l = new vector(a.size1);
	for (int i=0; i<a.size1; i++) {
	    l[i] = a[i,i];
	}
	int changed=0;
	rotations = 0;
		   	
	int[] largest = new int[a.size1-1];
	for(int i=0; i<a.size1-1; i++) {
	    largest[i] = a.size1-1;
	}
	for (int i=0; i<a.size1-1; i++){
	    for (int j=i+1; j<a.size1; j++) {
		if( Abs(a[i,j]) > Abs(a[i,largest[i]]) ) {
		    largest[i] = j;
		}
	    }
	}

	do {
	    changed = 0;
	    for (int r=0; r<a.size1-1; r++) {
		changed += this.single(r, largest[r]);

		for (int j=r+1; j<a.size1; j++) {
		    if(Abs(a[r,j])>Abs(a[r,largest[r]])) {
			largest[r] = j;
		    }
		}
	    }
	} while(changed != 0);    
    }//classicJacobi
    

    bool cyclicSweep() {
	bool changed = false;
	int p, q;
	int n = a.size1;
	for (p=0; p<n; p++) {
	    for (q=p+1; q<n; q++) {
		rotations++;
		double phi = 0.5*Atan2(2*a[p,q], l[q]-l[p]);
		double c = Cos(phi);
		double s = Sin(phi);
		double app = c*c*l[p]-2*s*c*a[p,q]+s*s*l[q];
		double aqq = s*s*l[p]+2*s*c*a[p,q]+c*c*l[q];
		if (app-l[p]!=0 || aqq-l[q]!=0) {
		    changed = true;
		    l[p] = app;
		    l[q] = aqq;
		    a[p,q] = 0.0;
		    for (int i=0; i<p; i++) {
			double aip = a[i, p];
			double aiq = a[i, q];
			a[i, p] = c*aip-s*aiq;
			a[i, q] = c*aiq+s*aip;
		    }
		    for (int i=p+1; i<q; i++) {
			double api = a[p,i];
			double aiq = a[i,q];
			a[p,i] = c*api-s*aiq;
			a[i,q] = c*aiq+s*api;
		    }
		    for (int i = q+1; i<n; i++) {
			double api = a[p,i];
			double aqi = a[q,i];
			a[p,i] = c*api-s*aqi;
			a[q,i] = c*aqi+s*api;
		    }
		    if (v!=null) {
			for (int i = 0; i<n; i++) {
			    double vip = v[i,p];
			    double viq = v[i,q];
			    v[i,p] = c*vip-s*viq;
			    v[i,q] = c*viq+s*vip;
			}
		    }
		}
	    }
	}
	// ReadKey(); for debugging!
      	return changed;
    }//cyclic sweep

    bool rowSweep(int r) {
	bool changed = false;
	int p=r;
	int q;
	int n = a.size1;
	for (q=p+1; q<n; q++) {
	    rotations++;
	    double phi = 0.5*Atan2(2*a[p,q], l[q]-l[p]);
	    double c = Cos(phi);
	    double s = Sin(phi);
	    double app = c*c*l[p]-2*s*c*a[p,q]+s*s*l[q];
	    double aqq = s*s*l[p]+2*s*c*a[p,q]+c*c*l[q];
	    if (app-l[p]!=0 || aqq-l[q]!=0) {
		changed = true;
		l[p] = app;
		l[q] = aqq;
		a[p,q] = 0.0;
        	for (int i=p+1; i<q; i++) {
		    double api = a[p,i];
		    double aiq = a[i,q];
		    a[p,i] = c*api-s*aiq;
		    a[i,q] = c*aiq+s*api;
		}
		for (int i = q+1; i<n; i++) {
		    double api = a[p,i];
		    double aqi = a[q,i];
		    a[p,i] = c*api-s*aqi;
		    a[q,i] = c*aqi+s*api;
		}
		if (v!=null) {
		    for (int i = 0; i<n; i++) {
			double vip = v[i,p];
			double viq = v[i,q];
			v[i,p] = c*vip-s*viq;
			v[i,q] = c*viq+s*vip;
		    }
		}
	    }
	}
	return changed;
    }
    
    /*
      Single rotation to use with classic jacobi
     */
    int single(int r, int k) {
	rotations++;
	int changed = 0;
	int p=r;
	int q=k;
	int n = a.size1;
	double phi = 0.5*Atan2(2*a[p,q], l[q]-l[p]);
	double c = Cos(phi);
	double s = Sin(phi);
	double app = c*c*l[p]-2*s*c*a[p,q]+s*s*l[q];
	double aqq = s*s*l[p]+2*s*c*a[p,q]+c*c*l[q];
	if (app-l[p]!=0 || aqq-l[q]!=0) {
	    changed = 1;
	    l[p] = app;
	    l[q] = aqq;
	    a[p,q] = 0.0;

	    for (int i=0; i<p; i++) {
		double aip = a[i, p];
		double aiq = a[i, q];
		a[i, p] = c*aip-s*aiq;
		a[i, q] = c*aiq+s*aip;
	    }
			    
	    for (int i=p+1; i<q; i++) {
		double api = a[p,i];
		double aiq = a[i,q];
		a[p,i] = c*api-s*aiq;
		a[i,q] = c*aiq+s*api;
	    }
	    for (int i = q+1; i<n; i++) {
		double api = a[p,i];
		double aqi = a[q,i];
		a[p,i] = c*api-s*aqi;
		a[q,i] = c*aqi+s*api;
	    }
	    if (v!=null) {
		for (int i = 0; i<n; i++) {
		    double vip = v[i,p];
		    double viq = v[i,q];
		    v[i,p] = c*vip-s*viq;
		    v[i,q] = c*viq+s*vip;
		}
	    }
	}
	return changed;
    }//single

    
}//diag
