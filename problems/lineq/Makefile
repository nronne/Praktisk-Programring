out.txt: main.exe
	mono $< > $@

main.exe: main.cs qrDecompositionGS.cs qrDecompositionGivens.cs  matlib.dll
	csc $(word 1, $^) $(word 2, $^) $(word 3, $^) -reference:$(lastword $^) -out:$@

LIBDIR = ../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll
