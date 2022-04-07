all: out.txt erf_pyx.png
	cat out.txt

erf_pyx.png: fig.pyxplot.gpi
	pyxplot $<

out.txt plot.txt: main.exe
	mono $< 1> out.txt 2> plot.txt

matlib.dll: vector.cs matrix.cs integrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt plot.txt erf_pyx.png
