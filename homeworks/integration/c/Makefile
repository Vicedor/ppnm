all: out.txt
	cat out.txt

out.txt: main.exe main.py
	mono $< > out.txt
	python3 main.py >> out.txt

matlib.dll: vector.cs matrix.cs integrate.cs
	mcs -target:library -out:$@ $^

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

clean:
	rm -r main.exe matlib.dll out.txt
