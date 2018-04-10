using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groupe_numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			var nums = Console.ReadLine()
				.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			var sizes = new int[3];

			foreach (var number in nums)
			{
				sizes[Math.Abs(number % 3)]++;
			}

			int[][] jagged_array = new int[3][];

			for (int counter = 0; counter < sizes.Length; counter++)
			{
				jagged_array[counter] = new int[sizes[counter]];
			}

			int[] index = new int[3];

			foreach (var number in nums)
			{
				var remainder = Math.Abs(number % 3);
				jagged_array[remainder][index[remainder]] = number;
				index[remainder]++;
			}

			for (int row = 0; row < jagged_array.Length; row++)
			{
				for (int col = 0; col < jagged_array[row].Length; col++)
				{
					Console.Write(jagged_array[row][col]  + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
