out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = ../../../matlib/matrix
MATLIB = $(LIBDIR)/vector.cs
MATLIB += $(LIBDIR)/matrix.cs
MATLIB += ../../lineq/qrDecompositionGS.cs
MATLIB += newton.cs
matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.txt *.log
