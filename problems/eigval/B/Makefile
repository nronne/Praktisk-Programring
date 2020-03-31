time_plot.svg: in.txt time.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key top left;\
	set grid;\
	set tics out;\
	set xlabel "t, sec";\
	set ylabel "N";\
	f(x) = c*x**3;\
	fit f(x) "<paste $(word 1, $^) $(word 2, $^)" via c;\
 	plot "<paste $(word 1, $^) $(word 2, $^)" ps 0.7 pt 7 title "cyclic"\
	, f(x) title sprintf("fit: (%.3e +/- %.3e)  x^3",c,c_err)\
	'| gnuplot

time.txt: mainB.exe in.txt
	for i in $$(cat $(word 2, $^)); do \
		\time -ao $@ -f "$$N %U" mono $< $$i > /dev/null; \
	done;

in.txt: 
	echo '10' > $@
	echo '20' >> $@
	echo '40' >> $@
	echo '80' >> $@
	echo '120' >> $@
	echo '160' >> $@
	echo '200' >> $@
	echo '300' >> $@
	echo '400' >> $@
	echo '500' >> $@


mainB.exe: mainB.cs diag.cs matlib.dll
	mcs $(word 1, $^) $(word 2, $^) -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC) 
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg

