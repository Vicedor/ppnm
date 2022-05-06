all: out.txt strat_pyx.png
	cat out.txt

strat_pyx.png: fig.pyxplot.gpi plot.txt
	pyxplot $<

out.txt plot.txt: main.exe
	mono $< 1> out.txt 2> plot.txt

matlib.dll: vector.cs matrix.cs montecarlo.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
