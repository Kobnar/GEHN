using System;

namespace GENN
{
	public class NeuronLayer
	{
		public NeuronLayer (int size, NeuronLayer parent)
		{
			// Instantiate a new layer
			Neurons = new Neuron[size];
			for (int i = 0; i < Neurons.Length; i++)
				Neurons [i] = new Neuron (parent);
		}

		public Neuron[] Neurons;
	}
}

