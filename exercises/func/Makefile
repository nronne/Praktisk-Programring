out.txt: main.exe
	mono $< >$@

main.exe: main.cs matlib.dll
	csc $< -reference:$(lastword $^)

LIBDIR := ../../matlib
SRC := $(LIBDIR)/integration/quado8.cs
matlib.dll: $(SRC)
	csc $< -target:library -out:$@

clean:
	$(RM) *.txt *.dll *.exe
