#include <stdio.h>
#include <math.h>
int main()
{
for(double x=-3.5;x<=3.5;x+=1)
printf("%lg %lg\n",x,tgamma(x));
return 0;
}
