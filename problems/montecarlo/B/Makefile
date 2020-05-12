
plot.svg: out.txt Makefile main.exe
	echo '\
	set term svg;\
	set out "$@";\
	set key top right;\
	set grid;\
	set tics out;\
	set xlabel "N";\
	set ylabel "";\
	set logscale y;\
	f(x) = A/sqrt(x);\
	fit f(x) "$<" using 1:3 via A;\
	plot "$<" using 1:2 w p ps 0.2 pt 7 title "residual"\
	, "$<" using 1:3 w p ps 0.3 pt 6 title "relative error"\
	, [10:1000] f(x) lc 1 title sprintf("fit: (%f)*1/sqrt(N)", A)\
	' | gnuplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = ../../../matlib/matrix
MATLIB = $(LIBDIR)/vector.cs
MATLIB += ../mc.cs
matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.txt *.dll *.log *.exe
