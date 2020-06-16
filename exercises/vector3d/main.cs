public class main{
    static int Main(){
	System.Console.Write("Example with vector v:\n");
	vector3d v = new vector3d(1.2, 1.5, 2.0);
	System.Console.Write("v = " + v + "\n");
	System.Console.Write("v_x = " + v.x + "\n");
	System.Console.Write("Changing v_x to 10 and v_y to 3.\n");
	v.x = 10;
	v.y=3;
	System.Console.Write("v_x = " + v.x + "\n");

	v.print("v=");
	System.Console.Write("Defining new vector u:");
	vector3d u = new vector3d(2, 5, 7);
	double a = 2;
	u.print("u=");

	System.Console.Write("Calculating 2*u, u+v and cross-product of u and v \n");
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
