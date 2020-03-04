all: Error_function.svg Gamma_function.svg

matlib.dll: my_fun.cs
	csc $^ -target:library -out:$@

main.exe: main.cs matlib.dll
	csc $<  -reference:matlib.dll -out:$@

erf_out.txt gamma_out.txt: main.exe
	mono $< gamma_out.txt  > erf_out.txt

Error_function.svg: erf_plot.gpi erf_out.txt erf_tab.txt
	gnuplot $< 

erf_tab.txt: Makefile
	echo "0.0 0.0" > $@
	echo "0.1 0.112462916" >> $@
	echo "0.5 0.520499878" >> $@
	echo "1.3 0.934007945" >> $@
	echo "2.2 0.998137154" >> $@

Gamma_function.svg: gamma_plot.gpi gamma_out.txt gamma_tab.txt
	gnuplot $<

PI := 3.14159265359
gamma_tab.txt: Makefile
	echo "0.5 $$(echo '1.0*sqrt($(PI))' | bc -l) " > $@
	echo "1.0 1.0" >> $@
	echo "1.5 $$(echo '0.5*sqrt($(PI))' | bc -l) " >> $@
	echo "2.0 1.0 " >> $@
	echo "3.0 2.0 " >> $@

clean: 
	$(RM) *.out *.dll *.txt
