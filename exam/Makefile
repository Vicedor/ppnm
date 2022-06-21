all: out.txt delta_pyx.png bessel_pyx.png fourier_pyx.png damped_pyx.png
	cat out.txt

delta_pyx.png: delta.pyxplot.gpi plt.txt
	pyxplot $<

bessel_pyx.png: bessel.pyxplot.gpi plt.txt tab.txt
	pyxplot $<

fourier_pyx.png: fourier.pyxplot.gpi plt.txt
	pyxplot $<

damped_pyx.png: damped.pyxplot.gpi plt.txt
	pyxplot $<

out.txt: main.exe
	mono $< 1> out.txt 2> plt.txt

matlib.dll: complex.cs cmath.cs cintegrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt plt.txt *.png
