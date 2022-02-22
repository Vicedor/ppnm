all: Out.txt
	cat Out.txt

Out.txt: main.exe input.data
	cat input.data | mono $< > $@

main.exe: main.cs genlist.dll
	mcs -reference:genlist.dll -out:$@ $<

genlist.dll: genlist.cs
	mcs -target:library -out:$@ $^

clean:
	rm -r Out.txt genlist.dll main.exe
