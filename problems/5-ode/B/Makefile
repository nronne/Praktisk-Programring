sir_model.svg: data.txt main.cs
	echo '\
	set term svg;\
	set out "$@";\
	set key top right;\
	set grid;\
	set tics out;\
	set xlabel "time in days";\
	set ylabel "people in ten thousands";\
	plot "$<" using 1:2 w l title "Susceptible"\
	, "$<" using 1:3 w l title "Infected"\
	, "$<" using 1:4 w l title "Recovered"\
	'| gnuplot



data.txt: main.exe main.cs
	mono $< > $@ 2> log.txt

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@ 

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../rk.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
