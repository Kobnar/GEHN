using NUnit.Framework;
using System;

namespace GENNTests
{
	[TestFixture ()]
	public class TestNeuralNet
	{
		GENN.Input[] inputs;

		[SetUp ()]
		public void Init ()
		{
			// Create the basic inputs layer
			inputs = new GENN.Input[] { new GENN.Input () };
		}

		[Test ()]
		public void TestConstructorSetsCorrectOutputCount ()
		{
			GENN.NeuralNet net = new GENN.NeuralNet(inputs, new int[] { 0, 0 }, 3);
			double[] output = net.Output;
			Assert.AreEqual (3, output.Length);
		}
	}
}

