using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target_Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimensions = Console.ReadLine()
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
			string snake = Console.ReadLine();
			var shot_params = Console.ReadLine()
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int rows = dimensions[0];
			int columns = dimensions[1];

			char[,] stairs = Fill_Matrix(snake, rows, columns);

			stairs = Fire_Shot(shot_params, stairs);

			stairs = Gravity(stairs);

			Print_Matrix(stairs);
		}

		private static void Print_Matrix(char[,] stairs)
		{
			var sb = new StringBuilder();
			for (int row = 0; row < stairs.GetLength (0); row++)
			{
				for (int col = 0; col < stairs.GetLength(1); col++)
				{
					sb.Append(stairs[row, col]);
					sb.AppendLine();
				}
			}
			string result = sb.ToString().TrimEnd();
			Console.WriteLine(result);
		}

		private static char[,] Gravity(char[,] stairs)
		{
			for (int col = 0; col < stairs.GetLength(1); col++)
			{
				int empty_rows = 0;
				for (int row = 0; row < stairs.GetLength(0); row++)
				{
					if (stairs[row,col] == ' ')
					{
						empty_rows++;
					}
					else
					{
						stairs[row + empty_rows, col] = stairs[row, col];
						stairs[row, col] = ' ';
					}
				}
			}
			return stairs;
		}

		private static char[,] Fire_Shot(int[] shot_params, char[,] stairs)
		{
			int inpact_row = shot_params[0];
			int inpact_column = shot_params[1];
			int radius = shot_params[2];
			for (int r = 0; r < stairs.GetLength(0); r++)
			{
				for (int c = 0; c < stairs.GetLength (1); c++)
				{
					int a = inpact_row - r;
					int b = inpact_column - c;
					double distance = Math.Sqrt(a * a + b * b);

					if (distance <= radius)
					{
						stairs[r, c] = ' ';
					}
				}
			}
			return stairs;
		}

		private static char[,] Fill_Matrix(string snake, int rows, int columns)
		{
			var matrix = new char[rows, columns];
			bool is_going_left = true;
			int index = is_going_left ? matrix.GetLength(1) : 0;
			int increment = is_going_left ? -1 : 1;
			int snake_index = 0;

			for (int row = rows - 1; row >= 0; row--)
			{
				for (int i = 0; i < columns; i++)
				{
					matrix[row, index] = snake[snake_index];
					snake_index++;
					if (snake_index > snake.Length)
					{
						snake_index = 0;
					}
					index += increment;
				}
				is_going_left = !is_going_left;
			}
			return matrix;
		}
	}
}
