#Read Command Line
#out.txt: readCmdLine.exe input.txt
#	mono $< $(cat input.txt) > out.txt
#readCmdLine.exe: readCmdLine.cs
#	mcs $< 
#clean:
#	$(RM) *.dll *.exe out*

# Read standard input
#out.txt: readStdInput.exe input.txt
#	mono $< < input.txt > out.txt
#readStdInput.exe: readStdInput.cs
#	mcs $< 
#clean:
#	$(RM) *.dll *.exe out*

# Read file
#out.txt: readFile.exe input.txt
#	mono $< input.txt out.txt
#readFile.exe: readFile.cs
#	mcs $< 
#clean:
#	$(RM) *.dll *.exe out*





all: out-cmdin.txt out-stdin.txt out-file.txt

out-cmdin.txt: readCmdLine.exe input.txt Makefile
	mono $< $$(cat input.txt) > $@ 

out-stdin.txt: readStdInput.exe input.txt Makefile
	mono $< < input.txt > out-stdin.txt

out-file.txt: readFile.exe input.txt Makefile
	mono $< input.txt out-file.txt


readCmdLine.exe: readCmdLine.cs
	mcs $<

readStdInput.exe:readStdInput.cs
	mcs $<

readFile.exe: readFile.cs
	mcs $< 


clean:
	$(RM) *.exe out*

