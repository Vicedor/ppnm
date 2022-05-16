all: out.txt wavefunction_pyx.png convergence_rmax_pyx.png convergence_rmin_pyx.png convergence_acc_pyx.png convergence_eps_pyx.png
	cat out.txt

convergence_rmax_pyx.png: conv_rmax.pyxplot.gpi convergence.txt
	pyxplot $<

convergence_rmin_pyx.png: conv_rmin.pyxplot.gpi convergence.txt
	pyxplot $<

convergence_acc_pyx.png: conv_acc.pyxplot.gpi convergence.txt
	pyxplot $<

convergence_eps_pyx.png: conv_eps.pyxplot.gpi convergence.txt
	pyxplot $<

wavefunction_pyx.png: fig.pyxplot.gpi wavefunction.txt
	pyxplot $<

out.txt wavefunction.txt: main.exe
	mono $< 1> out.txt 2> wavefunction.txt

matlib.dll: vector.cs matrix.cs qrgs.cs root.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt *.png wavefunction.txt convergence.txt
