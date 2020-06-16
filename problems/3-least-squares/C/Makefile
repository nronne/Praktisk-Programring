Plot_Rutherford_Soddy_unc.svg: plotC.gpi fit.txt data.txt
	gnuplot $<

out.txt data.txt fit.txt: main.exe
	mono main.exe 

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../../2-linear-equations/lib/qrDecompositionGS.cs
SRC += ../lib/ols.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
