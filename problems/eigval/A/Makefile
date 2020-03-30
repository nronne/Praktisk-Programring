.SILENT: Plot_box_wavefun.svg Plot_box_energy.svg

all: Plot_box_wavefun.svg Plot_box_energy.svg

outB.txt: mainB.exe
	mono $< >$@

mainB.exe: mainB.cs mainA.cs diag.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) $(word 3, $^) -reference:$(lastword $^) -out:$@

Plot_box_wavefun.svg: box_wavefun.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key bottom left;\
	set grid;\
	set tics out;\
	set xlabel "x";\
	set ylabel "psi(x)";\
	plot "$<" w l title "calculated"\
	,sqrt(2) lt 2 notitle\
	,-sqrt(2) lt 2 notitle\
	'| gnuplot


Plot_box_energy.svg: box_energies.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key left;\
	set tics out;\
	set grid;\
	set xlabel "n";\
	set ylabel "E_n";\
	set xrange [0:20];\
	plot "$<" u 1:2 w l title "calculated"\
	,"$<" u 1:3 w l title "exact"\
	'| gnuplot


outA.txt box_energies.txt box_wavefun.txt: mainA.exe  
	mono $< > outA.txt

mainA.exe: mainA.cs diag.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg

