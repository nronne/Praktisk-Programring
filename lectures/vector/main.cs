class main{
static int Main(){
	int n=3;
	vector v=new vector(n);
	vector u=new vector(n);
	for(int i=0;i<n;i++){
		v[i]=i+1;
		u[i]=-2*i-1;
	}
	v.print("v   = ");
	u.print("u   = ");
	(u+v).print("u+v = ");
	vector w=u+v;
	w.print("w   = ");
	(v*2).print("2*v = ");
return 0;
}
}
