all: out.txt
	cat out.txt

out.txt plot.txt: main.exe
	mono $< > out.txt

matlib.dll: vector.cs matrix.cs montecarlo.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
