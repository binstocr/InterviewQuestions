using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace InterviewProblems
{
	internal class Program
	{
		private static void Main()
		{
			// Problem 1
			string output = ReverseString("This is my test string!");
			Console.WriteLine(output);

			// Problem 2
			var permutations = GetStringPermutations("Test");
			foreach (var permutation in permutations)
				Console.WriteLine(permutation);

			// Problem 3
			var fluffy = new AnimalSpeech(Animal.Cat);
			// The following assert fails because of a bug.  Fix the bug.
			var meow = fluffy.Speak();
			Debug.Assert(meow == "meow", string.Format("Why is the cat {0}ing when it should be meowing?", meow));
		}

		/// <summary>
		/// This method takes any string as input, and returns the same string in reverse order.
		/// </summary>
		/// <param name="input">Any string of any length</param>
		/// <returns>The string in reverse order</returns>
		private static string ReverseString(string input)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// This method takes any string and returns a collection containing all combinations
		/// of strings using all letters in that string.  For example, if you input a string
		/// that has a length of 10, all strings in the output collection will also have a length
		/// of ten with each letter in the original string appearing exactly once in each string.
		/// </summary>
		/// <param name="input">The string for which all permutations are desired.</param>
		/// <returns>A collection of all permutations of the input string</returns>
		private static IEnumerable<string> GetStringPermutations(string input)
		{
			throw new NotImplementedException();
		}
	}
}
