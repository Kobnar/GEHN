using System;
using System.Runtime.InteropServices;

namespace NeuralNetEd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			GENN.Input[] inputs = new GENN.Input[] { new GENN.Input() };
			Console.WriteLine("Creating the genesis Neuron input: {0}...", inputs[0].Output);
			GENN.Neuron neuron = new GENN.Neuron (inputs);
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine ("--------------------");
				Console.WriteLine ("Neuron #{0}", i);
				Console.WriteLine ("\tWeights: {0}", neuron.Weights);
				Console.WriteLine ("\tBias: {0}", neuron.Bias);
			}
		}
	}
}
