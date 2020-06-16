all: Plot_time.svg out.txt

main.exe: main.cs matlib.dll
	mcs $<  -reference:$(lastword $^) -out:$@

out.txt: main.exe
	mono $< >$@

Plot_time.svg: time1.txt time2.txt time3.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key top left;\
	set tics out;\
	set xlabel "N";\
	set ylabel "t [sec]";\
	set log x;\
	set log y;\
	f(x) = (x/c)**3+c0;\
	g(x) = (x/s)**3+s0;\
	h(x) = (x/a)**3+a0;\
	fit f(x) "$(word 1, $^)" via c, c0;\
	fit g(x) "$(word 2, $^)" via s, s0;\
	fit h(x) "$(word 3, $^)" via a, a0;\
	plot [10:500][0.01:1] "$(word 1, $^)" lc 1 ps 0.7 pt 7 title "cyclic"\
	, "$(word 2, $^)" lc 2 ps 0.7 pt 7 title "single eigenvalue" \
	, "$(word 3, $^)" lc 3 ps 0.7 pt 7 title "all - row by row" \
	, [60:150] f(x) lc 1 title sprintf("fit: (x/%.f1)^3+%.f2",c,c0)\
	, [60:300] g(x) lc 2 title sprintf("fit: (x/%.f1)^3+%.f2",s,s0)\
	, [11:60] h(x) lc 3 title sprintf("fit: (x/%.f1)^3+%.f2",a,a0)\
	'| gnuplot


TIME=time
time1.txt: mainB1.exe in1.txt
	for i in $$(cat $(word 2, $^)); do \
		$(TIME) --append --output=temp.txt -f "%U" mono $< $$i > /dev/null; \
	done;
	@paste $(word 2, $^) temp.txt > $@
	$(RM) temp.txt

time2.txt: mainB2.exe in2.txt
	for i in $$(cat $(word 2, $^)); do \
		$(TIME) --append --output=temp.txt -f "%U" mono $< $$i > /dev/null; \
	done;
	@paste $(word 2, $^) temp.txt > $@
	$(RM) temp.txt

time3.txt: mainB3.exe in3.txt
	for i in $$(cat $(word 2, $^)); do \
		$(TIME) --append --output=temp.txt -f "%U" mono $< $$i > /dev/null; \
	done;
	@paste $(word 2, $^) temp.txt > $@
	$(RM) temp.txt

in1.txt: 
	echo '80' > $@
	echo '85' >> $@
	echo '90' >> $@
	echo '95' >> $@
	echo '100' >> $@
	echo '105' >> $@

in2.txt: 
	echo '100' > $@
	echo '125' >> $@
	echo '150' >> $@
	echo '175' >> $@
	echo '200' >> $@
	echo '225' >> $@


in3.txt: 
	echo '15' > $@
	echo '20' >> $@
	echo '25' >> $@
	echo '30' >> $@
	echo '35' >> $@
	echo '40' >> $@


mainB1.exe: mainB1.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

mainB2.exe: mainB2.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

mainB3.exe: mainB3.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../diag.cs
matlib.dll: $(SRC) 
	mcs $^ -target:library -out:$@

make clean:
	$(RM) *.exe *.txt *.dll *.svg *.log

