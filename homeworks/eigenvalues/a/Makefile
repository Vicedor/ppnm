all: out.txt
	cat $<

out.txt: main.exe input.txt
	mono $< > $@ -input:input.txt

matlib.dll: vector.cs matrix.cs jacobi.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
