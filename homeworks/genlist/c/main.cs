using System;
using static System.Console;

public static class main{
	public static void Main(string[] args) {
		genlist<int> a = new genlist<int>();
		a.push(1);
		a.push(2);
		a.push(3);
		for (a.start(); a.current != null; a.next()) {
			WriteLine(a.current.item);
		}
	}
}
