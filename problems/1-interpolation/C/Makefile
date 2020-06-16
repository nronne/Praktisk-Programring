All: Plot_cub.svg

Plot_cub.svg: plot_cub.gpi sin_values.txt sin_cspline.txt
	gnuplot $<

out.txt sin_values.txt sin_cspline.txt: main.exe
	mono $< >out.txt

main.exe: main.cs matlib.dll
	mcs $< -r:$(lastword  $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += ../interpolation.cs
matlib.dll: $(SRC)
	mcs $^ -t:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg
