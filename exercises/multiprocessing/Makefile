all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -out:$@ $<

clean:
	rm -r Out.txt main.exe
