using System;
using System.Runtime.InteropServices;
using GENN;

namespace NeuralNetEd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Define xor data
			int[][] xor_data = new int[4][] {
				new int[2] { 0, 0 }, new int[2] { 0, 1 },
				new int[2] { 1, 0 }, new int[2] { 1, 1 },
			};

			int[] xor_results = new int[4] {
				1, 0,
				0, 1
			};

			// Create gene pool
			Input[] inputs = new Input[2] { new Input (), new Input () };
			GENN.GenePool pool = new GENN.GenePool(inputs, 100, 1, new int[2] {4, 4});
			for (int i = 0; i < 1000; i++)
			{
				int train_idx = i % xor_data.Length;
				inputs [0].Value = xor_data [train_idx] [0];
				inputs [1].Value = xor_data [train_idx] [1];
				pool.Step ();
			}
		}
	}
}
