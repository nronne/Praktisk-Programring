#include <stdio.h>
#include <math.h>
int main()
{
for(double x=-2.5;x<=2.5;x+=0.5)
printf("%10.3f %20.14f\n",x,erf(x));
return 0;
}
