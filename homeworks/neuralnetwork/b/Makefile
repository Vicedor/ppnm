all: ann.png

ann.png: fig.pyxplot.gpi out.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

matlib.dll: vector.cs matrix.cs mini.cs ann.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt ann.png
