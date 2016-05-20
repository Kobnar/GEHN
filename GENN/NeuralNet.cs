using System;
using System.Collections.Generic;

namespace GENN
{
	public class NeuralNet
	{
		// Private data stores
		private Input[] _InputLayer;
		private Neuron[][] _HiddenLayers;
		private Neuron[] _OutputLayer;

		// Static class members
		public static double ErrorThreshold = 0.9;

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.NeuralNet"/> class.
		/// </summary>
		/// <param name="inputLayer">Input layer.</param>
		/// <param name="outputCount">Output count.</param>
		/// <param name="hiddenWidth">Hidden width.</param>
		/// <param name="hiddenDepth">Hidden depth.</param>
		public NeuralNet (Input[] inputLayer, int[] hiddenDimensions, int outputCount)
		{
			// Copy reference to input layer
			_InputLayer = inputLayer;

			// Start a running "last layer" tag (for depth == 0 edge case)
			Input[] lastLayer = inputLayer;


			// Allocate memory for hidden layers and create hidden neurons linked to previous depth layer
			int hiddenDepth = hiddenDimensions.Length;
			int hiddenWidth;
			_HiddenLayers = new Neuron[hiddenDepth][];
			for (int d = 0; d < hiddenDepth; d++) {
				hiddenWidth = hiddenDimensions [d];
				_HiddenLayers [d] = new Neuron[hiddenWidth];
				for (int w = 0; w < hiddenWidth; w++) {
					if (d != 0)
						_HiddenLayers [d] [w] = new Neuron (_HiddenLayers [d - 1]);
					else
						_HiddenLayers [d] [w] = new Neuron (_InputLayer);
				}

				// Update "last layer" tag
				if (d == hiddenDepth - 1)
					lastLayer = _HiddenLayers [d];
			}

			// Allocate memory for output layer and create neurons linked to last hidden layer
			_OutputLayer = new Neuron[outputCount];
			for (int o = 0; o < outputCount; o++)
				_OutputLayer [o] = new Neuron (lastLayer);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.NeuralNet"/> class by "breeding" two nets.
		/// </summary>
		/// <param name="mate">Mate.</param>
		public NeuralNet (NeuralNet mother, NeuralNet father)
		{
			// Copy reference to the input layer
			_InputLayer = mother.InputLayer;

			// Allocate memory for hidden layers and copy each neuron in the net
			int hiddenDepth = mother.HiddenLayers.Length;
			int hiddenLayerWidth;
			_HiddenLayers = new Neuron[hiddenDepth][];
			for (int d = 0; d < hiddenDepth; d++) {
				hiddenLayerWidth = mother.HiddenLayers [d].Length;
				_HiddenLayers[d] = new Neuron[hiddenLayerWidth];
				for (int w = 0; w < hiddenLayerWidth; w++) {
					if (d == 0)
						_HiddenLayers[d][w] = new Neuron(
							InputLayer, mother.HiddenLayers[d][w], father.HiddenLayers[d][w], ErrorThreshold);
					else
						_HiddenLayers[d][w] = new Neuron(
							_HiddenLayers[d - 1], mother.HiddenLayers[d][w], father.HiddenLayers[d][w], ErrorThreshold);
				}
			}

			// Allocate memory for output layer and copy each neuron
			_OutputLayer = new Neuron[mother.OutputLayer.Length];
			for (int o = 0; o < mother.OutputLayer.Length; o++)
				_OutputLayer [o] = new Neuron (
					_HiddenLayers[hiddenDepth - 1], mother.OutputLayer [o], father.OutputLayer [o], ErrorThreshold);
		}

		/// <summary>
		/// Gets the input layer.
		/// </summary>
		/// <value>The input layer.</value>
		protected Input[] InputLayer
		{
			get { return _InputLayer; }
		}

		/// <summary>
		/// Gets the hidden layers.
		/// </summary>
		/// <value>The hidden layers.</value>
		protected Neuron[][] HiddenLayers
		{
			get { return _HiddenLayers; }
		}

		/// <summary>
		/// Gets the output layer.
		/// </summary>
		/// <value>The output layer.</value>
		protected Neuron[] OutputLayer
		{
			get { return _OutputLayer; }
		}

		/// <summary>
		/// The output values of the <see cref="NeuralNet"/> as an array of decimal values.
		/// </summary>
		public double[] Output
		{
			get
			{
				double[] output = new double[_OutputLayer.Length];
				for (int i = 0; i < _OutputLayer.Length; i++)
					output [i] = _OutputLayer [i].Output;
				return output;
			}
		}
	}
}

