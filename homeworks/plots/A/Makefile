erf.pyxplot.png: erf.data.txt erf.tab.txt Makefile
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel '$$ x$$' \n\
		set ylabel '$$ y$$' \n\
		set title 'error function' \n\
		set key left top \n\
		plot [-1:1] [-1:1] '$<' index 0 using 1:2 with lines title 'error function',\ \n\
		'erf.tab.txt' using 1:2 with points pointtype 3 title 'tab' \n\
		" | tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -r Out.txt main.exe erf.data.txt erf.pyxplot.png
