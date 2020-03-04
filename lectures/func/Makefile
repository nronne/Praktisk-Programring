out.txt: main.exe
	mono $< 1> $@ 2> log
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC = $(LIBDIR)/integration/quado8.cs
SRC += $(LIBDIR)/integration/quado4.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe out* log*
