all: out.txt ode45_pyx.png
	cat out.txt

out.txt: main.exe
	mono $< 1> out.txt 2> plot.txt

ode45_pyx.png: fig.pyxplot.gpi
	pyxplot $<

matlib.dll: vector.cs matrix.cs ode.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt ode45_pyx.png plot.txt
