
all: Plot_box_wavefun.svg Plot_box_energy.svg

outB.txt: mainB.exe
	mono $< >$@

mainB.exe: mainB.cs mainA.cs diag.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) $(word 3, $^) -reference:$(lastword $^) -out:$@


LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg

