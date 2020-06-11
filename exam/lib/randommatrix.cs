using System;

public partial class rndMat {
    public static matrix randomMatrix(int n, int m) {
	matrix mat = new matrix(n, m);
	Random rnd = new Random();
	for (int i = 0; i<n; i++) {
	    for (int j = 0; j < m; j++) {
		mat[i,j] = 10*rnd.NextDouble();
	    }
	}
	return mat;
    } // randomMatrix

    public static vector randomVector(int n) {
	vector vec = new vector(n);
	Random rnd = new Random();
	for (int i = 0; i<n; i++) {
	    vec[i] = 10 * rnd.NextDouble();
	}
	return vec;
    } //randomVector

}
