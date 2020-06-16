out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs cmath.dll
	mcs $(CSFLAGS) -reference:cmath.dll -out:main.exe main.cs

CDIR = ../../matlib/complex
cmath.dll: $(CDIR)/complex.cs $(CDIR)/cmath.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f out* *.exe
