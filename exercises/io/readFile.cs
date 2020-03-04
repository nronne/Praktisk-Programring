class main {
    static int Main(string[] fileName){
	var infile = new System.IO.StreamReader(fileName[0]);
	var outfile = new System.IO.StreamWriter(fileName[1]);
	do {
	string s = infile.ReadLine();
	if (s==null) {break;} 
	string[] args = s.Split(" ");
	double d = 0;
	for(int i = 0; i < args.Length; i++) {
	    d = System.Convert.ToDouble(args[i]);
	    outfile.Write("cos({0}) = {1:f2}\n", args[i], System.Math.Cos(d));
	}
	} while(true);
	
	infile.Close();
	outfile.Close();
    return 0;
    }
}
