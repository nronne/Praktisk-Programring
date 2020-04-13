sincos.svg: out.txt main.cs
	echo '\
	set term svg;\
	set out "$@";\
	set key top right;\
	set grid;\
	set tics out;\
	set xlabel "t";\
	set ylabel "f(t)";\
	plot "$<" using 1:2 w l title "integrated sin(t)"\
	, "$<" using 1:3 w l title "integrated cos(t)"\
	'| gnuplot



out.txt: main.exe main.cs rk.cs
	mono $< > $@ 2> log.txt

main.exe: main.cs rk.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) -reference:$(lastword $^) -out:$@ 

LIBDIR = ../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
