using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpl
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[,] table = { {10, 3,  1, 3},
								{20, 3,  2, 4},
								{30, 4,  1, 2},
								{ 0, -10, -20, -30} 
			};
			double[] result = new double[2];
			double[,] table_result;
			Simplex S = new Simplex(table);
			table_result = S.Calculate(result);
			Console.WriteLine("Решенная симплекс-таблица:");
			for (int i = 0; i < table_result.GetLength(0); i++)
			{
				for (int j = 0; j < table_result.GetLength(1); j++)
					Console.Write(table_result[i, j] + " ");
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine("Решение:");
			Console.WriteLine("X[1] = " + result[0]);
			Console.WriteLine("X[2] = " + result[1]);
			Console.ReadLine();
		}
	}
}
