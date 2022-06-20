all: out.txt bessel_pyx.png
	cat out.txt

bessel_pyx.png: fig.pyxplot.gpi plt.txt
	pyxplot $<

out.txt: main.exe main.py
	mono $< 1> out.txt 2> plt.txt
	python3 main.py >> out.txt

matlib.dll: complex.cs cmath.cs cintegrate.cs integrate.cs new_integrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
