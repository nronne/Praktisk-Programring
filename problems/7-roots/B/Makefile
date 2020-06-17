Plot_waveFun.svg: data.txt main.cs Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key top right;\
	set grid;\
	set tics out;\
	set xlabel "r";\
	set ylabel "f";\
	plot "$<" using 1:2 w l title "found wavefunction"\
	, "$<" using 1:3 w l title "analytic wavefunction"\
	'| gnuplot

out.txt data.txt: main.exe
	mono $< 1> out.txt 2> error.log  

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = ../../../matlib/
MATLIB = $(LIBDIR)/matrix/vector.cs
MATLIB += $(LIBDIR)/matrix/matrix.cs
MATLIB += ../../2-linear-equations/lib/qrDecompositionGS.cs
MATLIB += newton.cs
MATLIB += ../../5-ode/rk.cs
matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.txt *.log *.dll
