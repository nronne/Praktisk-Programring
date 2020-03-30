using static System.Console;
using static System.Math;

public class diagJacobi {
    public vector l {get; set;} // stores eigenvalues
    public matrix a {get; set;} // strict upper triangular of a is destroyed.
    public matrix v {get; set;} // stores eigenvectors
    public int sweeps {get; set;}
    /*
      Remember: a = v^Tav=d;
     */
    
    public diagJacobi(matrix x, bool eigVec=false) {
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
	do {
	    changed = this.cyclicSweep();
	    sweeps++;
	} while(changed);
	
    }//constructor

    bool cyclicSweep() {
	bool changed = false;
	int p, q;
	int n = a.size1;
	for (p=0; p<n; p++) {
	    for (q=p+1; q<n; q++) {
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
    }

    //
    
}//diag
