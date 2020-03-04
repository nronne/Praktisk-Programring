class main {
    static int Main(){
	System.IO.TextReader stdIn = System.Console.In;
	do {
	string s = stdIn.ReadLine();
	if (s==null) {break;} 
	string[] args = s.Split(" ");
	double d = 0;
	for(int i = 0; i < args.Length; i++) {
	    d = System.Convert.ToDouble(args[i]);
	    System.Console.Write("cos({0}) = {1:f2}\n", args[i], System.Math.Cos(d));
	}
	} while(true);
	
	return 0;
    }
}
