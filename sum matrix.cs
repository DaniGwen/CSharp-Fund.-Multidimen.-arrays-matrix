using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_problem_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var rows_Columns = Console.ReadLine()
				.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[,] matrix = new int[rows_Columns[0], rows_Columns[1]];

			for (int row = 0; row < rows_Columns[0]; row++)
			{
				var values_rows = Console.ReadLine()
					.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				for (int columns = 0; columns < rows_Columns[1]; columns++)
				{
					matrix[row, columns] = values_rows[columns]; 
				}
			}

			int sum = 0;

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int columns = 0; columns < matrix.GetLength(1); columns++)
				{
					sum += matrix[row, columns];
				}
			}

			Console.WriteLine(matrix.GetLength (0));
			Console.WriteLine(matrix.GetLength (1));
			Console.WriteLine(sum);
		}
	}
}
