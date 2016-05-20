using System;
using System.Collections.Generic;

namespace GENN
{
	/// <summary>
	/// A place where organisms are born, live and die.
	/// </summary>
	public class GenePool
	{
		// Private data stores
		private Input[] InputLayer;
		private List<NeuralNet> Pool;

		public GenePool (Input[] inputLayer, int organismCount, int outputCount, int hiddenWidth = 4,
			int hiddenDepth = 1)
		{
			InputLayer = inputLayer;
			for (int i = 0; i < organismCount; i++)
				Pool.Add (new NeuralNet (InputLayer, outputCount, hiddenWidth, hiddenDepth));
		}

		/// <summary>
		/// Get/Set the input layer of the <see cref="GenePool"/>.
		/// </summary>
		/// <value>The input.</value>
		public decimal[] Input
		{
			get
			{
				decimal[] input = new decimal[InputLayer.Length];
				for (int i = 0; i < InputLayer.Length; i++)
					input [i] = InputLayer [i].Value;
			}
			set
			{
				for (int i = 0; i < value.Length; i++)
					InputLayer [i].Value = value [i];
			}
		}

	}
}

