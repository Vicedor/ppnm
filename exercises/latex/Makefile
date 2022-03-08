all: ms.pdf

ms.pdf: ms.tex exp_pyx.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

exp_pyx.pdf: fig.pyxplot.gpi out.txt tab.txt
	pyxplot $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs

%.exe: %.cs
	mcs -target:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -target:library $(addprefix -r:, $(filter %.dll, $^)) $(filter %.cs, $^)

clean:
	rm -r main.exe exp_pyx.pdf out.txt ms.pdf ms.aux ms.log
