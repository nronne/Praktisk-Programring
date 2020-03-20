Plot_Rutherford_Soddy_unc.svg: plotC.gpi outwunc.txt data.txt
	gnuplot $<

Plot_Rutherford_Soddy.svg: plot.gpi out.txt data.txt
	gnuplot $<

out.txt data.txt outwunc.txt: main.exe
	mono main.exe 

main.exe: main.cs ols.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) -reference:$(lastword $^) -out:$@

LIBDIR = ../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../lineq/qrDecompositionGS.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll
