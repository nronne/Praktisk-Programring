using static System.Console;
using static System.Math;
class main{
	string s="old string\n";
	int i=666;

	static double mult(double a,double b){
		int i=1;
		return i*a*b;
	}

	static int Main(){
		double x=1.23;
		int nmax=100;
		string s="helloøæåµ\n";
		Write(s);
		int two=2;
		int one=1;
		if(two>one){Write("2>1\n");}
		else{Write("2!>1\n");}

		int i=0;
		for(i=0;i<10;++i){Write("i={0}\n",i);}

		i=0;
		while(i<10){Write("while loop: i={0}\n",i);i++;}

		do {Write("at least once\n");} while (false);
		// while (false) {Write("never get here\n");}
		
		Write("pi={0:e2}\n",PI);

		string[] v = new string[10];
		for(i=0;i<10;++i){v[i]=$"{i}";}
		for(i=0;i<10;++i){Write("v[{0}]={1}\n",i,v[i]);}
		Write($"v.Length={v.Length}\n");
		System.Array.Resize(ref v,v.Length+1);
		Write($"v.Length={v.Length}\n");
		for(i=0;i<v.Length;++i){Write("v[{0}]={1}\n",i,v[i]);}
	return 0;
	}
}
