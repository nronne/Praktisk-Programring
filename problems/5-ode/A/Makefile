sincos.svg: data.txt main.cs Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key bottom left;\
	set grid;\
	set tics out;\
	f(x) = sin(x);\
	g(x) = cos(x);\
	set xlabel "t";\
	set ylabel "y";\
	plot "$<" using 1:2 w l title "integrated sin(t)"\
	, "$<" using 1:3 w l title "integrated cos(t)"\
	, f(x) dt 4 title "analytic sin(t)"\
	, g(x) dt 4 title "analytic cos(t)"\
	'| gnuplot



data.txt: main.exe main.cs
	mono $< > $@ 2> log.txt

main.exe: main.cs  matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@ 

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../rk.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
