public struct vector3d{
    double _x;
    double _y;
    double _z;
    
    public double x{
	get{return _x;}
	set{_x = value;}
    }
    public double y{
	get{return _y;}
	set{_y = value;}
    }
    public double z{
	get{return _z;}
	set{_z = value;}
    }

    //Constructor
    public vector3d(double x=0, double y=0, double z=0){
	_x = x;
	_y = y;
	_z = z;
    }

    //Overrides
    public override string ToString(){
	return "(" + x + ", " + y + ", " + z +  ")";
    } 

    
    //Operators
    public static vector3d operator+(vector3d v, vector3d u){
	return new vector3d(v.x+u.x, v.y+u.y, v.z+u.z);
    }

    public static vector3d operator-(vector3d v, vector3d u){
	return new vector3d(v.x-u.x, v.y-u.y, v.z-u.z);
    }
    
    public static vector3d operator*(double a, vector3d v){
	return new vector3d(a*v.x, a*v.y, a*v.z);
    }

    public static vector3d operator*(vector3d v, double a){
	return a*v;
    }
    
    //Methods
    public double dotProduct(vector3d u){
	return this.x*u.x + this.y*u.y + this.z*u.z;
    }

    public vector3d vectorProduct(vector3d u){
	return new vector3d(this.y*u.z-u.y*this.z, this.x*u.z-u.x*this.z, this.x*u.y-u.x*this.y);
    }

    public double magnitude(){
	return System.Math.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
    } 

    public void print(string s=""){
	System.Console.Write(s);
	System.Console.Write(this);
	System.Console.Write("\n");
    }

}
