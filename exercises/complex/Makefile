Out.txt: main.exe
	mono main.exe > Out.txt

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:cmath.dll $^

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:main.exe main.cs
