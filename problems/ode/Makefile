out.txt: main.exe main.cs rk.cs
	mono $< > $@ 2> log.txt

main.exe: main.cs rk.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) -reference:$(lastword $^) -out:$@ 

LIBDIR = ../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
