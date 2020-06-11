Plot_Rutherford_Soddy_unc.svg: plotC.gpi outwunc.txt data.txt
	gnuplot $<

out.txt data.txt outwunc.txt: main.exe
	mono main.exe 

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../../lineq/lib/qrDecompositionGS.cs
SRC += ../lib/ols.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
