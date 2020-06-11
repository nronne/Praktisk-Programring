out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

MATLIB = ../matlib
LIB = lib
SRC += $(MATLIB)/matrix/vector.cs
SRC += $(MATLIB)/matrix/matrix.cs
SRC += $(LIB)/gklbidiag.cs
SRC += $(LIB)/randommatrix.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll
