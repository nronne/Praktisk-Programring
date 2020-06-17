using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;

class main {
    public static int Main() {
	TextReader stdin = Console.In;
	
	List<double>[] data = new List<double>[3];
	List<double> energy = new List<double>();
	List<double> sigma = new List<double>();
	List<double> error = new List<double>();
	data[0] = energy;
	data[1] = sigma;
	data[2] = error;
	
	do{
	    string s=stdin.ReadLine();
	    if(s==null)break;
	    char[] separators = new char[] {' '};
	    string[] w=s.Split(separators,StringSplitOptions.RemoveEmptyEntries);
	    data[0].Add(double.Parse(w[0]));
	    data[1].Add(double.Parse(w[1]));
	    data[2].Add (double.Parse(w[2]));
	}while(true);
       		
	Write("==== Higgs Boson data from Cern fit to Breit-Wigner formula ====\n");
	/* double: E, vector: m, Gamma, A */
	
	Func<double, vector, double> F = delegate(double E, vector p) {
	    double val = p[2]/(Pow(E-p[0], 2) + p[1]*p[1]/4);
	    return val;
	};
		
	Func<vector, double> D = delegate(vector p) {
	    double val = 0;
	    for(int i = 0; i<data[0].Count; i++) {
		val+=Pow(F(data[0][i], p) - data[1][i], 2)/data[2][i]/data[2][i];
	    }
	    return val;
	};
	vector xstart = new vector(110, 2, 6);
	vector xmin = minimizer.qnewton(D, xstart);
	Write("\nThe found values for the Higgs Boson are:\n");
	Write($"Mass:     {xmin[0]:f2}\n");
	Write($"Width:    {xmin[1]:f2}\n\n");

	
	return 0;
    }
}
