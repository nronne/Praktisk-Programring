CSFLAGS = -warn:4

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs cmath.dll
	mcs $(CSFLAGS) -reference:cmath.dll -out:main.exe main.cs

CDIR=../../matlib/complex
cmath.dll: $(CDIR)/cmath.cs $(CDIR)/complex.cs
	mcs $(CFLAGS) -target:library -out:$@ $^  # $^ = all prerequisites

.PHONEY:clean
clean:
	rm --force out* *.dll *.exe
