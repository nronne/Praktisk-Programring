
plot.svg: tab.txt predict.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key top right;\
	set grid;\
	set tics out;\
	set xlabel "x";\
	set ylabel "f(x)";\
	plot "$(word 1, $^)" using 1:2 w l title "function values"\
	, "$(word 2, $^)" using 1:2 w p ps 0.3 pt 7 title "predicted values"\
	' | gnuplot

tab.txt predict.txt: main.exe
	mono $< 1> tab.txt 2>predict.txt

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = ../../../matlib/matrix
MATLIB = $(LIBDIR)/vector.cs
MATLIB += $(LIBDIR)/matrix.cs
MATLIB += ../../minimization/minimizer.cs
MATLIB += ../network.cs
matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.txt *.dll *.log *.exe
