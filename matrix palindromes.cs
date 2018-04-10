using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Matrix_of_Palindromes
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			int rows = input[0];
			int columns = input[1];

			int[,] matrix = new int[rows, columns];
			char[] alphabet = new char[26];

			for (char i = 'a' ; i < 'z'; i++)
			{
				alphabet[i] = i;
			}

		}
	}
}
