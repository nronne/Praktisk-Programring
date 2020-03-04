plot.svg: plot.gpi out.txt
	gnuplot $<
out.txt: main.exe Makefile
	mono $< a=0 y0=0 y1=1 b=100 1> $@ 2>log
main.exe: main.cs matlib.dll
	mcs -reference:matlib.dll $<
matlib.dll: ../../matlib/matrix/vector.cs ../../matlib/ode/ode.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe log* out*
