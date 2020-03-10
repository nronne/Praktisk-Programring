all:ms.pdf

ms.pdf: ms.tex plot-exp.tex
	pdflatex $<
	pdflatex $<

main.exe: main.cs exp.cs matlib.dll
	mcs $(word 1,$^) $(word 2,$^) -reference:$(lastword $^)
	
plot-exp.tex: plot-exp.gpi out-exp.txt out-table.txt
	gnuplot $<

E=2.718281828
out-table.txt: Makefile
	cat /dev/null > $@
	echo "-2 $$(echo '1/$E/$E' | bc -l)" >>$@
	echo "-1 $$(echo '1/$E' | bc -l)" >>$@
	echo '0 1' >>$@
	echo '1 $E' >>$@
	echo "2 $$(echo '$E*$E' | bc -l)" >>$@
	echo "3 $$(echo '$E*$E*$E' | bc -l)" >>$@
	echo "4 $$(echo '$E*$E*$E*$E' | bc -l)" >>$@
	echo "5 $$(echo '$E*$E*$E*$E*$E' | bc -l)" >>$@

out-exp.txt: main.exe
	mono $< > $@

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/ode/ode.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.log *.aux *.pdf *.dvi out* *.eps plot-exp.tex *.exe *.dll

test:
	echo $(SRC)
