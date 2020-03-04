using System;
using System.IO;
class stdinouterr{
static int Main(){
	TextReader stdin  = Console.In;
	TextWriter stdout = Console.Out;
	TextWriter stderr = Console.Error;
	stdout.WriteLine("# x sin(x)");
	stderr.WriteLine("# x sin(x)");
	do{
		string s=stdin.ReadLine();
		if(s==null)break;
		string[] words=s.Split(' ',',','\t');
		foreach(var word in words){
			double x=double.Parse(word);
			stdout.WriteLine("{0} {1}",x,Math.Sin(x));	
			stderr.WriteLine("{0} {1}",x,Math.Sin(x));	
		}
	}while(true);
return 0;
}
}
