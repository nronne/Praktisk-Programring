all: Erf.svg Gamma.svg

Erf.svg  : erf.gpi   out.erf.txt   ; gnuplot $<
Gamma.svg: gamma.gpi out.gamma.txt ; gnuplot $<

out.erf.txt  : main-erf.exe
	mono $< > $@ 2> log.erf.txt
out.gamma.txt: main-gamma.exe
	mono $< > $@ 2> log.gamma.txt

main-erf.exe: main-erf.cs matlib.dll
	mcs -r:matlib.dll $<
main-gamma.exe: main-gamma.cs matlib.dll cmath.dll
	mcs -r:matlib.dll,cmath.dll $<

LIBDIR=../../matlib

cmath.dll: $(LIBDIR)/complex/cmath.cs $(LIBDIR)/complex/complex.cs
	mcs $^ -t:library -out:$@

SRC= erf.cs gamma.cs \
	$(LIBDIR)/integration/quadc7.cs \
	$(LIBDIR)/integration/quado8.cs \
	$(LIBDIR)/integration/quado4.cs
matlib.dll: $(SRC) cmath.dll
	mcs -r:cmath.dll -t:library -out:$@ $(SRC)

clean:
	rm -f *.exe *.dll out* *.svg *.png *.jpg gamma.gpi erf.gpi log* table*

table.erf.txt: erf.c
	tcc -run $< > $@

table.gamma.txt: gamma.c
	tcc -run $< > $@

gamma.gpi: Makefile table.gamma.txt
	cat /dev/null > $@
	echo 'set encoding utf8' >> $@
	echo 'set title "Gamma-function: computed vs. tabulated"' >> $@
	echo 'set term svg background rgb "white"' >> $@
	echo 'set out "Gamma.svg"' >> $@
	echo 'set xlabel "x"' >> $@
	echo 'set ylabel "y"' >> $@
	echo 'set xzeroaxis' >> $@
	echo 'set yzeroaxis' >> $@
	echo 'set tics out' >> $@
	echo 'set key bottom right' >> $@
	echo 'plot [:5][-5:5] \' >> $@
	echo ' "out.gamma.txt" with lines title "Γ(x)" \' >> $@
	echo ',"table.gamma.txt" with points pt 7 title "tabulated"' >> $@

erf.gpi: Makefile table.erf.txt
	echo 'set title "Error function: computed vs. tabulated"' > $@
	echo 'set encoding utf8' >> $@
	echo 'set term svg background rgb "white"' >> $@
	echo 'set out "Erf.svg"' >> $@
	echo 'set xlabel "x"' >> $@
	echo 'set ylabel "y"' >> $@
	echo 'set xzeroaxis' >> $@
	echo 'set yzeroaxis' >> $@
	echo 'set tics out' >> $@
	echo 'set key bottom right' >> $@
	echo 'plot [][-1.5:1.5] \' >> $@
	echo ' "out.erf.txt" with lines title "erf(x)" \' >> $@
	echo ',"table.erf.txt" with points pt 7 title "tabulated"' >> $@
	echo 'set term jpeg small size 128,64 crop' >>$@
	echo 'set out "erf.jpg"' >>$@
	echo 'set notitle' >>$@
	echo 'set noxlabel' >>$@
	echo 'set noylabel' >>$@
	echo 'set nokey' >>$@
	echo 'set tics out' >>$@
	echo 'set grid' >>$@
	echo 'set xtics format ""' >>$@
	echo 'set ytics format ""' >>$@
	echo 'replot' >>$@
