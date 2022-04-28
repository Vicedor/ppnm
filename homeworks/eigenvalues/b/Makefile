all: eigenvalues_pyx.png conv_rmax_pyx.png conv_dr_pyx.png

conv_dr_pyx.png: conv_dr.pyxplot.gpi conv.txt
	pyxplot $<

conv_rmax_pyx.png: conv_rmax.pyxplot.gpi conv.txt
	pyxplot $<

eigenvalues_pyx.png: fig.pyxplot.gpi out.txt
	pyxplot $<

out.txt conv.txt: main.exe input.txt
	mono $< 1> out.txt 2> conv.txt -input:input.txt

matlib.dll: vector.cs matrix.cs jacobi.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt conv.txt eigenvalues_pyx.png conv_rmax_pyx.png conv_dr_pyx.png
