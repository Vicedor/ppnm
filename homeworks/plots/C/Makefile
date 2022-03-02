all: imgam.pyxplot.png

imgam.pyxplot.png: imgam.data.txt Makefile
	echo '\
		set terminal png ;\
		set output "$@" ;\
		set xlabel "Re($$z$$)" ;\
		set ylabel "Im($$z$$)" ;\
		set title "Gamma function complex" ;\
		set key below ;\
		set grid ;\
		set size 7 square ;\
		plot 3d [][][0:25] "$<" index 0 using 2:1:3 with surface col black fillcol green title "$$\Gamma$$($$z$$)" ;\
		' | tee log.gpi | pyxplot

imgam.data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -reference:cmath.dll -out:$@ $<

clean:
	rm -r main.exe imgam.pyxplot.png
