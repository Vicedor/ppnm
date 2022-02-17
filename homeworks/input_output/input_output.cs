using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class InputOutput {
	public static int Main(string[] args) {
		List<string> exerciseTwoArgs = new List<string>();
		Dictionary<string, string> exerciseThreeArgs = new Dictionary<string, string>();
		foreach(string arg in args){
			if (int.TryParse(arg, out _)) {
				exerciseTwoArgs.Add(arg);
			}
			else {
				string[] splitted = arg.Split(':');
				exerciseThreeArgs[splitted[0]] = splitted[1];
			}
		}

		WriteLine("Exercise 1 with 1, 2, 3, 4 and 5");
		_exerciseOne();
		WriteLine("\nExercise 2 with 1, 2, 3, 4 and 5");
		_exerciseTwo(exerciseTwoArgs.ToArray());
		WriteLine("\nFor exercise 3 with 1, 2, 3, 4 and 5, check the out.txt file.");
		return _exerciseThree(exerciseThreeArgs);
	}

	private static void _exerciseOne() {
		char[] delimiters = {' ', '\t', '\n'};
		StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line != null; line = ReadLine()) {
			string[] words = line.Split(delimiters, options);
			foreach(string word in words) {
				double x = double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}

	private static void _exerciseTwo(string[] args) {
		foreach(string arg in args) {
			double x = double.Parse(arg);
			WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
	}

	private static int _exerciseThree(Dictionary<string, string> args) {
		string infile, outfile;
		if (!args.TryGetValue("-input", out infile)) {
			Error.WriteLine("Wrong argument");
			return 1;
		}
		if (!args.TryGetValue("-output", out outfile)) {
			return 1;
		}
		StreamReader instream = new System.IO.StreamReader(infile);
		StreamWriter outstream = new System.IO.StreamWriter(outfile);
		for (string line=instream.ReadLine(); line!=null; line=instream.ReadLine()) {
			double x;
			if (double.TryParse(line, out x)) {
				outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
			else {
				Error.WriteLine("Non-double input in file");
				return 1;
			}
		}
		instream.Close();
		outstream.Close();
		return 0;
	}
}
