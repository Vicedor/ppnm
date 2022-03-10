all: out.txt qspline_pyx.pdf

out.txt: main.exe input.txt
	mono $< > $@ -input:input.txt

qspline_pyx.pdf: fig.pyxplot.gpi out.txt input.txt
	pyxplot $<

main.exe: main.cs qspline.dll
	mcs -target:exe -out:$@ -reference:qspline.dll $<

qspline.dll: qspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -r main.exe qspline.dll out.txt qspline_pyx.pdf
