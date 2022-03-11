all: Out.txt spring_pyx.png

spring_pyx.png: fig.pyxplot.gpi
	pyxplot fig.pyxplot.gpi

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

matlib.dll: integrate.cs vector.cs ode.cs
	mcs -target:library -out:$@ $^

clean:
	rm -r matlib.dll main.exe Out.txt spring_pyx.png
