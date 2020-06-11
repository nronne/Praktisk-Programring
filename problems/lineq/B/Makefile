out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
QRLIB = ../lib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += $(QRLIB)/qrDecompositionGS.cs
SRC += $(QRLIB)/qrDecompositionGivens.cs
SRC += $(QRLIB)/randommatrix.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll
