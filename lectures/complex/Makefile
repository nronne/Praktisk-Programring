out.txt: main.exe
	mono $< >$@

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll $<

libdir=../../matlib/complex
cmath.dll: $(libdir)/complex.cs $(libdir)/cmath.cs
	mcs -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe out*
