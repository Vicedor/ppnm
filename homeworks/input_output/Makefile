Out.txt: main.exe
	echo 1 2 3 4 5 | mono main.exe 1 2 3 4 5 -input:input.txt -output:out.txt > Out.txt

main.exe: input_output.cs
	mcs -out:main.exe input_output.cs
