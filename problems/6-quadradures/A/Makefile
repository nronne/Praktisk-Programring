
out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $< 

LIBDIR = ../lib
matlib.dll: $(LIBDIR)/integrator.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.exe *.txt
