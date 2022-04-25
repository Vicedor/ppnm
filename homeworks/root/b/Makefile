all: out.txt wavefunction.png
	cat out.txt

wavefunction.png: fig.pyxplot.gpi wavefunction.txt
	pyxplot $<

out.txt wavefunction.txt: main.exe
	mono $< 1> out.txt 2> wavefunction.txt

matlib.dll: vector.cs matrix.cs qrgs.cs root.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt wavefunction.png wavefunction.txt
