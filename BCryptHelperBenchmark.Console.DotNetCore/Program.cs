using BCrypt;
using System;

namespace BCryptHelperBenchmark.Console.DotNetCore
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("Work factor\tTime taken (ms)");
			for (int workFactor = 4; workFactor < 20; ++workFactor)
			{
				DateTime start = DateTime.Now;

				int numIterations = 100;
				for (int i = 0; i < numIterations; ++i)
				{
					BCryptHelper.HashPassword("prova", BCryptHelper.GenerateSalt(workFactor));
					if (i % 10 == 0)
					{
						System.Console.Write("{0}\t\tMeasuring ({1}%)...\r", workFactor, (float)i / numIterations * 100);
					}
				}

				DateTime end = DateTime.Now;
				System.Console.WriteLine("{0}\t\t{1} ms\t\t\t", workFactor, end.Subtract(start).TotalMilliseconds / numIterations);
			}
		}
	}
}
