all: out.txt lspline_pyx.pdf

out.txt: main.exe input.txt
	mono $< > $@ -input:input.txt

lspline_pyx.pdf: fig.pyxplot.gpi out.txt input.txt
	pyxplot $<

main.exe: main.cs lspline.dll
	mcs -target:exe -out:$@ -reference:lspline.dll $<

lspline.dll: lspline.cs
	mcs -target:library -out:$@ $<

clean:
	rm -r main.exe lspline.dll out.txt lspline_pyx.pdf
