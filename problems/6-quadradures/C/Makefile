
out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $< 

LIBDIR = ../lib
MATLIBDIR = ../../../matlib/integration
matlib.dll: $(MATLIBDIR)/quado8.cs $(LIBDIR)/integrator.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.txt *.dll
