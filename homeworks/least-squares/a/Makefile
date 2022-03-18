all: out.txt tab.txt least_squares_pyx.png
	cat out.txt

out.txt tab.txt: main.exe input.txt
	mono $< 1> tab.txt 2> out.txt -input:input.txt

least_squares_pyx.png: fig.pyxplot.gpi tab.txt
	pyxplot $<

matlib.dll: vector.cs matrix.cs qrgs.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt least_squares_pyx.png
