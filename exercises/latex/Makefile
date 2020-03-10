all: ms.pdf

ms.pdf: ms.tex plot_bessel.tex
	pdflatex $<
	pdflatex $<

plot_bessel.tex: bessel_plot.gpi out.txt out_tab.txt
	gnuplot $<

out.txt log: main.exe
	mono $< > $@ 2>log 

out_tab.txt: Makefile
	echo "0.5 $$(echo 's(0.5)/0.5' | bc -l) $$(echo 's(0.5)/(0.5*0.5) - c(0.5)/0.5' | bc -l) $$(echo '(3-0.5*0.5)*s(0.5)/(0.5*0.5*0.5) - 3*c(0.5)/(0.5*0.5)' | bc -l)" > $@
	echo "1.5 $$(echo 's(1.5)/1.5' | bc -l) $$(echo 's(1.5)/(1.5*1.5) - c(1.5)/1.5' | bc -l) $$(echo '(3-1.5*1.5)*s(1.5)/(1.5*1.5*1.5) - 3*c(1.5)/(1.5*1.5)' | bc -l)" >> $@
	echo "3 $$(echo 's(3)/3' | bc -l) $$(echo 's(3)/(3*3) - c(3)/3' | bc -l) $$(echo '(3-3*3)*s(3)/(3*3*3) - 3*c(3)/(3*3)' | bc -l)" >> $@
	echo "5 $$(echo 's(5)/5' | bc -l) $$(echo 's(5)/(5*5) - c(5)/5' | bc -l) $$(echo '(3-5*5)*s(5)/(5*5*5) - 3*c(5)/(5*5)' | bc -l)" >> $@
	echo "7 $$(echo 's(7)/7' | bc -l) $$(echo 's(7)/(7*7) - c(7)/7' | bc -l) $$(echo '(3-7*7)*s(7)/(7*7*7) - 3*c(7)/(7*7)' | bc -l)" >> $@
	echo "9 $$(echo 's(9)/9' | bc -l) $$(echo 's(9)/(9*9) - c(9)/9' | bc -l) $$(echo '(3-9*9)*s(9)/(9*9*9) - 3*c(9)/(9*9)' | bc -l)" >> $@
	echo "11 $$(echo 's(11)/11' | bc -l) $$(echo 's(11)/(11*11) - c(11)/11' | bc -l) $$(echo '(3-11*11)*s(11)/(11*11*11) - 3*c(11)/(11*11)' | bc -l)" >> $@
	echo "13 $$(echo 's(13)/13' | bc -l) $$(echo 's(13)/(13*13) - c(13)/13' | bc -l) $$(echo '(3-13*13)*s(13)/(13*13*13) - 3*c(13)/(13*13)' | bc -l)" >> $@

main.exe: main.cs bessel.cs matlib.dll
	csc $(word 1,$^) $(word 2,$^) -reference:$(lastword $^)

LIBDIR = ../../matlib
SRC := $(LIBDIR)/ode/ode.cs
SRC += $(LIBDIR)/matrix/vector.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@


clean: 
	$(RM) *.dll *.exe *.aux *.txt *.eps log *.pdf *.dvi log
