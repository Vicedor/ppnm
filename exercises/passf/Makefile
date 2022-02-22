all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

table.dll: table.cs
	mcs -target:library -out:$@ $^

main.exe: passf.cs table.dll
	mcs -out:$@ -reference:table.dll $<

clean:
	rm -r Out.txt main.exe table.dll
