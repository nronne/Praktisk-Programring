
Plot.svg: tab.txt predict.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key bottom right;\
	set grid;\
	set tics out;\
	set xlabel "x";\
	set ylabel "f(x)";\
	plot "$(word 1, $^)" using 1:2 w l title "f(x)=cos(x)"\
	, "$(word 2, $^)" using 1:2 w p ps 0.3 pt 7 title "predicted f(x)"\
	, "$(word 1, $^)" using 1:3 w l title "-sin(x)"\
	, "$(word 2, $^)" using 1:3 w p ps 0.3 pt 7 title "predicted derivative"\
	, "$(word 1, $^)" using 1:4 w l title "sin(x)"\
	, "$(word 2, $^)" using 1:4 w p ps 0.3 pt 7 title "predicted anti-derivative"\
	' | gnuplot

tab.txt predict.txt: main.exe
	mono $< 1> tab.txt 2>predict.txt

main.exe: main.cs matlib.dll
	mcs -r:matlib.dll  $<

LIBDIR = ../../../matlib
MATLIB := $(LIBDIR)/matrix/vector.cs
MATLIB += $(LIBDIR)/matrix/matrix.cs
MATLIB += $(LIBDIR)/complex/complex.cs
MATLIB += $(LIBDIR)/complex/cmath.cs

MATLIB += ../../8-multimin/minimizer.cs
MATLIB += ../lib/network.cs
MATLIB += ../lib/annGauss.cs
MATLIB += ../lib/myFuns.cs

matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.txt *.dll *.log *.exe
