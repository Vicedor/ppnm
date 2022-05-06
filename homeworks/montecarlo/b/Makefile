all: out.txt mc_pyx.png
	cat out.txt

out.txt plot.txt: main.exe
	mono $< 1> out.txt 2> plot.txt

mc_pyx.png: fig.pyxplot.gpi plot.txt
	pyxplot $<

matlib.dll: vector.cs matrix.cs montecarlo.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt plot.txt mc_pyx.png
