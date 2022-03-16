out.txt: main.exe matrixinput.txt vectorinput.txt
	mono $< > $@ -inputmatrix:matrixinput.txt -inputvector:vectorinput.txt

matlib.dll: vector.cs matrix.cs qrgs.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
