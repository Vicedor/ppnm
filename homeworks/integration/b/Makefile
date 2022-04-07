all: out.txt
	cat out.txt

out.txt: main.exe main.py
	mono $< > $@
	python3 main.py >> $@

matlib.dll: vector.cs matrix.cs integrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
