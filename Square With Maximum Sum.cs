using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Square_With_Maximum_Sum
{
	class Program
	{

		static void Main(string[] args)
		{

			var rows_Columns = Console.ReadLine()
				.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int row = rows_Columns[0];
			int column = rows_Columns[1];
			int[,] matrix = Read_Matrix(row,column);

			int sum = 0;
			int row_Index = 0, column_index = 0;


			for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
			{
				for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
				{
					var temp_sum = matrix[rows, columns] 
						+ matrix[rows, columns + 1] 
						+ matrix[rows + 1, columns] 
						+ matrix[rows + 1, columns + 1];

					if (temp_sum > sum)
					{
						sum = temp_sum;
						row_Index = rows;
						column_index = columns;
					}
				}
			}

			Console.WriteLine(matrix[row_Index, column_index] + " " + matrix[row_Index , column_index + 1]);
			Console.WriteLine(matrix[row_Index + 1, column_index ] + " " + matrix[row_Index + 1, column_index + 1] );
			Console.WriteLine(sum);
			
		}

		static int[,] Read_Matrix(int row, int column)
		{
			int[,] matrix = new int[row, column];

			for (int rowCount = 0; rowCount < row; rowCount++)
			{
				var values_rows = Console.ReadLine()
					.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				for (int columnsCount = 0; columnsCount < column; columnsCount++)
				{
					matrix[rowCount, columnsCount] = values_rows[columnsCount];
				}
			}
			return matrix;
		}
	}
}
