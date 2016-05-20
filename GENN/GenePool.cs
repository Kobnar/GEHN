using System;
using System.Linq;
using System.Collections.Generic;

namespace GENN
{
	/// <summary>
	/// A place where organisms are born, live and die.
	/// </summary>
	public class GenePool
	{
		// Private data stores
		private int _Generation;
		private Input[] InputLayer;
		private NeuralNet[] Pool;

		public GenePool (Input[] inputLayer, int organismCount, int outputCount, int[] hiddenDimensions)
		{
			// Copy the input layer
			InputLayer = inputLayer;

			// Populate the gene pool
			Pool = new NeuralNet [organismCount];
			for (int i = 0; i < organismCount; i++)
				Pool[i] = new NeuralNet (InputLayer, hiddenDimensions, outputCount);
		}

		/// <summary>
		/// Get/Set the input layer of the <see cref="GenePool"/>.
		/// </summary>
		/// <value>The input.</value>
		public double[] Inputs
		{
			get
			{
				double[] input = new double[InputLayer.Length];
				for (int i = 0; i < InputLayer.Length; i++)
					input [i] = InputLayer [i].Value;
				return input;
			}
		}

		/// <summary>
		/// An array of ideal outputs.
		/// </summary>
		public double[] TargetOutput;

		/// <summary>
		/// Checks the error of a "candidate" <see cref="NeuralNetwork"/> output by averaging the difference between
		/// <see cref="TargetOutput"/> and the candidate's <see cref="Output"/>.
		/// </summary>
		/// <returns>The error.</returns>
		/// <param name="candidate">Candidate.</param>
		private double CheckError(NeuralNet candidate)
		{
			double[] output = candidate.Output;
			double[] errors = new double[TargetOutput.Length];
			for (int i = 0; i < TargetOutput.Length; i++)
			{
				errors [i] = (TargetOutput [i] - output [i]) / TargetOutput[i];
			}
			return errors.Average ();
		}

		private void Sort()
		{
			Pool.OrderBy (net => net.Output);
		}

		public double NextGeneration()
		{
			_Generation++;
			KillOff ();
			Breed ();
			return CheckError (BestCandidate);
		}

		public int Generation
		{
			get
			{
				return _Generation;
			}
		}

//		public NeuralNet BestCandidate
//		{
//			get
//			{
//				
//			}
//		}
//
//		public double BestFitnessScore
//		{
//			get
//			{
//				
//			}
//		}

	}
}

