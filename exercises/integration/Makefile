all: Out.txt fig.erf.png
	cat Out.txt

fig.erf.png: fig.erf.gpi
	pyxplot $<

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2>erf.data.txt

main.exe: main.cs matlib.dll
	mcs -target:exe -reference:matlib.dll $<

matlib.dll: integrate.cs vector.cs ode.cs
	mcs -target:library -out:$@ $<

clean:
	rm -r matlib.dll main.exe Out.txt fig.erf.png erf.data.txt
