using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GENN
{
	/// <summary>
	/// A single neuron. Links to other neurons by reference through accessing an array of neurons.
	/// </summary>
	public class Neuron : Input
	{
		private static Random _Rand = new Random ();
		public static double ErrorThreshold = 0.99;

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.Neuron"/> class using a layer of root
		/// <see cref="GENN.Input"/> nodes. 
		/// </summary>
		/// <param name="inputs">Inputs.</param>
		public Neuron (Input[] inputs)
		{
			_Inputs = inputs;
			Randomize ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.Neuron"/> class using a layer of other
		/// <see cref="GENN.Neuron"/> nodes.
		/// </summary>
		/// <param name="inputs">Inputs.</param>
		public Neuron (Neuron[] inputs)
		{
			// Copy a reference to the input array
			_Inputs = inputs;
			Randomize ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GENN.Neuron"/> class by "splicing" the "genes" (properties)
		/// of each neuron.
		/// </summary>
		/// <param name="mother">Mother.</param>
		/// <param name="father">Father.</param>
		public Neuron(Neuron mother, Neuron father)
		{
			// Make a simple array of the two parents
			Neuron[] parents = new Neuron[2] { mother, father };

			// Copy inputs and allocate memory for weights
			_Inputs = mother.Inputs;
			_Weights = new double[Inputs.Length];

			// Splice genes
			int p;
			for (int i = 0; i <= Inputs.Length; i++)
			{
				// Pick a random parent
				p = _Rand.Next (2);

				// Splice properties
				if (i < Inputs.Length)
					_Weights [i] = CopyGene (parents[p].Weights [i]);
				else
					_Bias = CopyGene (parents[p].Bias);
			}
		}

		/// <summary>
		/// Randomizes "genes" in the neuron.
		/// </summary>
		private void Randomize ()
		{
			// Set random weights for each input
			_Weights = new double[Inputs.Length];
			for (int i = 0; i < Weights.Length; i++)
				_Weights [i] = _Rand.NextDouble ();

			// Set a random bias
			_Bias = _Rand.NextDouble ();
		}

		/// <summary>
		/// Copies a single "gene". Introduces the chance of generating a new random number.
		/// </summary>
		/// <returns>The gene.</returns>
		/// <param name="value">Value.</param>
		private double CopyGene(double value)
		{
			if (_Rand.NextDouble () > ErrorThreshold)
				return _Rand.NextDouble ();
			else
				return value;
		}

		/// <summary>
		/// An array of input neurons.
		/// </summary>
		private Input[] _Inputs;
		public Input[] Inputs {
			get { return _Inputs; }
		}

		/// <summary>
		/// An array of input weights corresponding to each neuron in Inputs.
		/// </summary>
		private double[] _Weights;
		public double[] Weights {
			get { return _Weights; }
		}

		/// <summary>
		/// This neuron's output bias.
		/// </summary>
		private double _Bias;
		public double Bias {
			get { return _Bias; }
		}

		/// <summary>
		/// Gets the total output of this neuron via sigmoid function.
		/// </summary>
		/// <value>The neuron's output.</value>
		public new double Output {
			get {
				double activation = 0;
				for (int i = 0; i < Inputs.Length; i++)
					activation += Inputs [i].Output * Weights [i];
				activation += Bias;
				return 1 / (1 + Math.Exp (activation));
			}
		}
	}
}

