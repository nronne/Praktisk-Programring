All: Plot_qua.svg Plot_lin.svg Plot_cub.svg

Plot_qua.svg: plot_qua.gpi sin_values.txt sin_qspline.txt
	gnuplot $<

Plot_lin.svg: plot_lin.gpi sin_values.txt sin_lspline.txt
	gnuplot $<

Plot_cub.svg: plot_cub.gpi sin_values.txt sin_cspline.txt
	gnuplot $<

out.txt sin_values.txt sin_lspline.txt sin_qspline.txt sin_cspline.txt: main.exe
	mono $< >out.txt

main.exe: main.cs interpolation.cs matlib.dll
	csc $(word 1, $^) $(word 2, $^) -reference:$(lastword  $^) -out:$@

LIBDIR = ../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
matlib.dll: $(SRC)
	csc $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll
