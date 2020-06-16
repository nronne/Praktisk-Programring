.SILENT: Plot_Rutherford_Soddy.svg

Plot_Rutherford_Soddy.svg: plot.gpi fit.txt data.txt
	gnuplot $<

out.txt fit.txt data.txt: main.exe
	mono main.exe > out.txt 

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
