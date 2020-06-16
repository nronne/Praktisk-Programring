all: Plot_rotations.svg Plot_time.svg out.txt
.SILENT: in.txt time1.txt time2.txt rot1.txt rot2.txt Plot_rotations.svg Plot_time.svg

Plot_rotations.svg: rot1.txt rot2.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set key top left;\
	set tics out;\
	set xlabel "N";\
	set ylabel "number of rotations";\
	set log x;\
	set log y;\
	f(x) = (x/c)**3+c0;\
	g(x) = (x/s)**3+s0;\
	fit f(x) "$(word 1, $^)" via c, c0;\
	fit g(x) "$(word 2, $^)" via s, s0;\
	plot [50:160] "$(word 1, $^)" lc 1 ps 0.7 pt 7 title "classic jacobi"\
	, "$(word 2, $^)" lc 2 ps 0.7 pt 7 title "cyclic sweep" \
	, [60:150] f(x) lc 1 title sprintf("fit: (x/%.f1)^3+%.f2",c,c0)\
	, [60:150] g(x) lc 2 title sprintf("fit: (x/%.f1)^3+%.f2",s,s0)\
	'| gnuplot

Plot_time.svg: time1.txt time2.txt Makefile
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
	fit f(x) "$(word 1, $^)" via c, c0;\
	fit g(x) "$(word 2, $^)" via s, s0;\
	plot [50:160] "$(word 1, $^)" lc 1 ps 0.7 pt 7 title "classic jacobi"\
	, "$(word 2, $^)" lc 2 ps 0.7 pt 7 title "cyclic sweep" \
	, [60:150] f(x) lc 1 title sprintf("fit: (x/%.f1)^3+%.f2",c,c0)\
	, [60:150] g(x) lc 2 title sprintf("fit: (x/%.f1)^3+%.f2",s,s0)\
	'| gnuplot


rot1.txt: rotClas.exe
	mono $< >$@

rot2.txt: rotJak.exe
	mono $< >$@


TIME=time
time1.txt: timedClas.exe in.txt
	for i in $$(cat $(word 2, $^)); do \
		$(TIME) --append --output=temp.txt -f "%U" mono $< $$i > /dev/null; \
	done;
	@paste $(word 2, $^) temp.txt > $@
	$(RM) temp.txt

time2.txt: timedJak.exe in.txt
	for i in $$(cat $(word 2, $^)); do \
		$(TIME) --append --output=temp.txt -f "%U" mono $< $$i > /dev/null; \
	done;
	@paste $(word 2, $^) temp.txt > $@
	$(RM) temp.txt


in.txt: 
	echo '70' > $@
	echo '80' >> $@
	echo '90' >> $@
	echo '100' >> $@
	echo '110' >> $@
	echo '120' >> $@
	echo '130' >> $@

rotJak.exe: rotJak.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

rotClas.exe: rotClas.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

timedJak.exe: timedJak.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

timedClas.exe: timedClas.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@


out.txt: main.exe
	mono $< 6 > $@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^) -out:$@

LIBDIR = ../../../matlib
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/matrix/matrix.cs
SRC += ../diag.cs
matlib.dll: $(SRC) 
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.exe *.txt *.dll *.svg *.log

