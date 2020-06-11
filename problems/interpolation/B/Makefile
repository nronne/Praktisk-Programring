All: Plot_qua.svg

Plot_qua.svg: plot_qua.gpi sin_values.txt sin_qspline.txt
	gnuplot $<

out.txt sin_values.txt  sin_qspline.txt: main.exe
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
