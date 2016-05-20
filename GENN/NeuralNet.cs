using System;
using System.Collections.Generic;

namespace GENN
{
	public class NeuralNet
	{
		// Private data stores
		private Input[] _InputLayer;
		private Neuron[,] _HiddenLayers;
		private Neuron[] _OutputLayer;

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.NeuralNet"/> class.
		/// </summary>
		/// <param name="inputLayer">Input layer.</param>
		/// <param name="outputCount">Output count.</param>
		/// <param name="hiddenWidth">Hidden width.</param>
		/// <param name="hiddenDepth">Hidden depth.</param>
		public NeuralNet (Input[] inputLayer, int outputCount, int hiddenWidth, int hiddenDepth)
		{
			// Copy reference to input layer
			_InputLayer = inputLayer;

			// Allocate memory for each array
			_HiddenLayers = new Neuron[hiddenDepth, hiddenWidth];
			_OutputLayer = new Neuron[outputCount];

			// Intantiate network
			for (int d = 0; d < hiddenDepth; d++)
				for (int w = 0; w < hiddenWidth; w++)
					_HiddenLayers [d, w] = Neuron (_HiddenLayers [d]);

			// Instantiate output layer
			for (int o = 0; o < outputCount; o++)
				_OutputLayer [o] = new Neuron (_HiddenLayers[hiddenDepth - 1]);
		}

		/// <summary>
		/// The output values of the <see cref="NeuralNet"/> as an array of decimal values.
		/// </summary>
		public decimal[] Output
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
	}
}

