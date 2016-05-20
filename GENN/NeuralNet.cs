using System;
using System.Collections.Generic;

namespace GENN
{
	public class NeuralNet
	{
		public NeuralNet (int inputCount, int hiddenWidth, int hiddenDepth, int outputCount)
		{
			// Allocate memory for each array
			_InputLayer = new Input[inputCount];
			_HiddenLayers = new Neuron[hiddenDepth, hiddenWidth];
			_OutputLayer = new Neuron[outputCount];

			// Instantiate input array
			for (int i = 0; i < inputCount; i++)
				_InputLayer[i] = new Input();

			// Intantiate network
			for (int d = 0; d < hiddenDepth; d++)
				for (int w = 0; w < hiddenWidth; w++)
					_HiddenLayers [d, w] = Neuron (_HiddenLayers [d]);

			// Instantiate output layer
			for (int o = 0; o < outputCount; o++)
				_OutputLayer [o] = new Neuron (_HiddenLayers[hiddenDepth - 1]);
		}

		private Input[] _InputLayer;
		private Neuron[,] _HiddenLayers;
		private Neuron[] _OutputLayer;

		/// <summary>
		/// The input values of the <see cref="NeuralNet"/>.
		/// </summary>
		private decimal[] Input
		{
			get
			{
				decimal[] input = new decimal[_InputLayer.Length];
				for (int i = 0; i < _InputLayer.Length; i++)
					input [i] = _InputLayer [i].Value;
				return input;
			}
			set
			{
				for (int i = 0; i < value.Length; i++)
					_InputLayer [i].Value = value [i];
			}
		}

		/// <summary>
		/// The output values of the <see cref="NeuralNet"/>.
		/// </summary>
		private decimal[] Output
		{
			get
			{
				decimal[] output = new decimal[_OutputLayer.Length];
				for (int i = 0; i < _OutputLayer.Length; i++)
					output [i] = _OutputLayer [i].Output;
				return output;
			}
		}

		/// <summary>
		/// Sets the state of the network's input and returns the resulting output according to the values contained
		/// in each neuron.
		/// </summary>
		/// <param name="input">Input.</param>
		public decimal[] GetOutput (double[] input)
		{
			Input = input;
			return Output;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.Neuron"/> class by "breeding" with another
		/// <see cref="GENN.Neuron"/>.
		/// </summary>
		/// <param name="mate">Mate.</param>
		public NeuralNet BreedWith(NeuralNet mate)
		{
			//return new NeuralNet (this, mate);
			return new NeuralNet (0, 0, 0, 0);
		}

		/// <summary>
		/// The fitness preference of this particular neural net (percentile of the stack?)
		/// </summary>
		public double Preference;

		/// <summary>
		/// The gender of this particular nural net. Neural nets will not breed with same-sexed neural nets (mostly).
		/// </summary>
		public double Gender;
	}
}

