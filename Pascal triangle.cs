using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Pascal_Triangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int height = int.Parse(Console.ReadLine());
			int current_width = 1;
			int[][] triangle = new int[height][];
			for (int current_array = 0; current_array < height; current_array++)
			{
				triangle[current_array] = new int[current_array + 1];
				triangle[current_array][0] = 1; 
				triangle[current_array][current_width - 1] = 1;
				current_width++;
				if (current_array > 2)
				{
					for (int width_counter = 1; width_counter < current_array -1; width_counter++)
					{
						triangle[current_array][width_counter] = 
							  triangle[current_array - 1][width_counter - 1]
							+ triangle[current_array - 1][width_counter];
					}
				}
			}
			for (int row = 0; row < triangle.Length - 1; row++)
			{
				for (int col = 0; col < triangle[col].Length; col++)
				{
					Console.WriteLine(triangle[row][col]);
				}
			}

		}
	}
}
