using static System.Console;
struct main{
	static int Main(){

	Write("--------------\n");
	static_writer.print();
	static_writer.s="static: new string\n";
	static_writer.print();

	Write("--------------\n");
	var sy=new struct_writer("struct: old string\n");
	sy.print();
	var sx=sy;
	sy.s="struct: new string\n";
	sy.print();
	sx.print();

	Write("--------------\n");
	var cy=new class_writer("class: old string\n");
	cy.print();
	var cx=cy;
	cy.s="class: new string\n";
	cy.print();
	cx.print();

	return 0;
	}
}

//static class
static public class static_writer{
	static public string s="static: old string\n";
	static public void print(){
		System.Console.Write(s);
	}
}
// struct
public struct struct_writer{
	public string s;
	public struct_writer(string input){s=input;} // constructor
	public void print(){
		System.Console.Write(s);
	}
}
// class
public class class_writer{
	public string s;
	public class_writer(string input){s=input;} // constructor
	public void print(){
		System.Console.Write(s);
	}
}
