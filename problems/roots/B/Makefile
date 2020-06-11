out.txt: main.exe
	mono $< 1> $@ 2> error.log  

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = ../../../matlib/
MATLIB = $(LIBDIR)/matrix/vector.cs
MATLIB += $(LIBDIR)/matrix/matrix.cs
MATLIB += ../../lineq/lib/qrDecompositionGS.cs
MATLIB += newton.cs
MATLIB += ../../ode/rk.cs
matlib.dll: $(MATLIB)
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.txt *.log *.dll
