all: gam.pyxplot.png lngam.pyxplot.png

gam.pyxplot.png: gam.data.txt gam.tab.txt Makefile
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel '$$ x$$' \n\
		set ylabel '$$ y$$' \n\
		set title 'gamma function' \n\
		set key left top \n\
		plot [][-5:5] '$<' index 0 using 1:2 with lines title 'gamma function',\ \n\
		'gam.tab.txt' using 1:2 with points pointtype 3 title 'tab' \n\
		" | tee log.gpi | pyxplot

lngam.pyxplot.png: gam.data.txt lngam.tab.txt Makefile
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel '$$ x$$' \n\
		set ylabel '$$ y$$' \n\
		set title 'log gamma function' \n\
		set key left top \n\
		plot [0:5][] '$<' index 1 using 1:2 with lines title 'lngamma function',\ \n\
		'lngam.tab.txt' using 1:2 with points pointtype 3 title 'tab' \n\
		" | tee log.gpi | pyxplot

gam.data.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -r main.exe gam.pyxplot.png lngam.pyxplot.png
