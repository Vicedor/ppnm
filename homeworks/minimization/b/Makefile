all: out.txt higgs.png
	cat out.txt

higgs.png: fig.pyxplot.gpi plot.txt
	pyxplot $<

out.txt plot.txt: main.exe tab.txt
	mono $< -input:tab.txt 1> out.txt 2> plot.txt

matlib.dll: vector.cs matrix.cs mini.cs genlist.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
