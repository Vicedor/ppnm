all: out.txt delta_pyx.png bessel_pyx.png
	cat out.txt

delta_pyx.png: delta.pyxplot.gpi plt.txt
	pyxplot $<

bessel_pyx.png: bessel.pyxplot.gpi plt.txt tab.txt
	pyxplot $<

out.txt: main.exe main.py
	mono $< 1> out.txt 2> plt.txt
	python3 main.py >> out.txt

matlib.dll: complex.cs cmath.cs cintegrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt plt.txt delta_pyx.png bessel_pyx.png
