public class main{
    static int Main(){
	System.Console.Write("Compiled!\n");
	vector3d v = new vector3d(1.2, 1.5, 2.0);
	System.Console.Write("v = " + v + "\n");
	System.Console.Write("vx = " + v.x + "\n");
	v.x = 10;
	v.y=3;
	System.Console.Write("vx = " + v.x + "\n");

	v.print("v=");
	vector3d u = new vector3d(2, 5, 7);
	double a = 2;
	u.print("u=");
	
	vector3d w = u*a;
	w.print("2*u = ");

	vector3d q = u+v;
	q.print("u+v = ");

	vector3d t = v.vectorProduct(u);
	t.print("u x v = ");

	System.Console.Write("Magnitude v = {0:f3}\n",v.magnitude());

	return 0;
}
}
