
Logistic.svg: logistic.gpi out.txt out_tab.txt
	gnuplot $<

out.txt: main.exe
	mono $< >$@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

LIBDIR := ../../matlib
SRC = $(LIBDIR)/ode/ode.cs
SRC += $(LIBDIR)/matrix/vector.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@


out_tab.txt: Makefile
	echo "0.5 $$(echo '1.0/(1.0+e(-0.5))' | bc -l) " > $@
	echo "1.0 $$(echo '1.0/(1.0+e(-1.0))' | bc -l) " >> $@
	echo "1.5 $$(echo '1.0/(1.0+e(-1.5))' | bc -l) " >> $@
	echo "2.0 $$(echo '1.0/(1.0+e(-2.0))' | bc -l) " >> $@
	echo "2.5 $$(echo '1.0/(1.0+e(-2.5))' | bc -l) " >> $@

clean:
	$(RM) *.txt *.exe *.svg *.dll log
