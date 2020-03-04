out.txt : main.exe                       # out.txt depends on main.exe
	mono main.exe > out.txt          # run main.exe, send output to out.txt

main.exe : main.cs world.dll             # main.exe depends on main.cs and world.dll
	mcs -reference:world.dll main.cs # compile main.cs and link with world.dll

world.dll : world.cs                     # world.dll depends on world.cs
	mcs -target:library world.cs     # compile world.cs into a library

clean:                                   # a phoney target, no dependencies
	rm -f out* *.exe *.dll           # remove all secondary files
