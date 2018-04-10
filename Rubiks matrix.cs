using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Matrix
{
	class Program
	{
		private static int[,] matrix;
		private static int rows;
		private static int columns;

		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			rows = dimentions[0];
			columns = dimentions[1];
			int number = 1;
			matrix = new int[dimentions[0], dimentions[1]];

			for (int row = 0; row < rows; row++)
			{
				for (int column = 0; column < columns; column++)
				{
					matrix[row, column] = number;
					number++;
				}
			}
			int command_count = int.Parse(Console.ReadLine());

			for (int i = 0; i < command_count; i++)
			{
				Parse_Command();
			}

			Rearrange_Matrix();
		}

		private static void Rearrange_Matrix()
		{
			int expected = 1;
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (matrix[row, col] == expected)
					{
						Console.WriteLine("No swap required");
					}
					else
					{
						for (int r = 0; r < rows; r++)
						{
							for (int c = 0; c < columns; c++)
							{
								if (matrix[r, c] == expected)
								{
									int temp = matrix[row, col];
									matrix[row, col] = matrix[r, c];
									matrix[r, c] = temp;
									Console.WriteLine($"Swap ({row}, {col}) with ({r},{c})");
									expected++;
									break;
								}
							}
						}
					}
					
				}
			}
		}

		private static void Parse_Command()
		{
			string[] commandArgs = Console.ReadLine().Split(' ');
			string command = commandArgs[1];
			int index = int.Parse(commandArgs[0]);
			int rotations = int.Parse(commandArgs[2]);

			switch (command)
			{
				case "up":
					Move_Column(index, rows - rotations);
					break;
				case "down":
					Move_Column(index, rotations);
					break;
				case "left":
					Move_Row(index, columns - rotations);
					break;
				case "right":
					Move_Row(index, rotations);
					break;

			}
		}

		private static void Move_Row(int index, int rotations)
		{
			rotations %= columns;
			int[] temp_array = new int[columns];
			for (int col = 0; col < columns; col++)
			{
				int replace_index = col + rotations;
				replace_index %= columns;
				temp_array[replace_index] = matrix[index, col];
			}
			for (int col = 0; col < columns; col++)
			{
				matrix[index, col] = temp_array[col];
			}
		}

		private static void Move_Column(int index, int rotations)
		{
			rotations %= rows;
			int[] temp_array = new int[rows];
			for (int row = 0; row < rows; row++)
			{
				int replace_index = row + rotations;
				replace_index %= rows;
				temp_array[replace_index] = matrix[index, row];
			}
			for (int row = 0; row < rows; row++)
			{
				matrix[row, index] = temp_array[row];
			}
		}
	}
}
