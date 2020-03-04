static class main{
static void Main(){
	for(double x=-3;x<=3;x+=0.25)
	System.Console.WriteLine(
		"{0,8:f3} {1,16:f8} {2,16:f8}",
		x,math.erf(x),math.erf2(x)
		);
}
}
