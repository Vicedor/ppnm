using System;
using static System.Console;

public static class main{
	public static void Main(string[] args) {
		genlist<double[]> list = new genlist<double[]>();
		char[] delimiters = {' ', '\t'};
		StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
		
		for (string line = ReadLine(); line != null; line = ReadLine()) {
			string[] words = line.Split(delimiters, options);
			int n = words.Length;
			double[] numbers = new double[n];

			for (int i=0; i<n; i++) {
				numbers[i] = double.Parse(words[i]);
			}
			list.push(numbers);
		}

		for (int i=0; i<list.size; i++) {
			double[] numbers = list.data[i];
			
			foreach(double number in numbers) {
				Write($"{number:e} ");
			}
			WriteLine();
		}
	}
}
