All: Plot_lin.svg

Plot_lin.svg: plot_lin.gpi sin_values.txt sin_lspline.txt
	gnuplot $<

out.txt sin_values.txt sin_lspline.txt: main.exe
	mono $< >out.txt

main.exe: main.cs matlib.dll
	mcs $< -r:$(lastword  $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += ../interpolation.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
