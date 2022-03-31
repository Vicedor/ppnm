all: out.txt ode45_pyx.png

out.txt: main.exe
	mono $< > out.txt

ode45_pyx.png: fig.pyxplot.gpi
	pyxplot $<

matlib.dll: vector.cs matrix.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt ode45_pyx.png
