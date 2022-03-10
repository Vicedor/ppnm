all: out.txt cspline_pyx.pdf

out.txt: main.exe input.txt
	mono $< > $@ -input:input.txt

cspline_pyx.pdf: fig.pyxplot.gpi out.txt input.txt
	pyxplot $<

main.exe: main.cs cspline.dll
	mcs -target:exe -out:$@ -reference:cspline.dll $<

cspline.dll: cspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -r main.exe cspline.dll out.txt cspline_pyx.pdf
