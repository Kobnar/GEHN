using NUnit.Framework;
using System;

namespace GENNTests
{
	[TestFixture ()]
	public class TestNeuron
	{
		private GENN.Input[] inputs;

		[SetUp]
		public void TestSetup()
		{
			// Create the basic inputs layer
			inputs = new GENN.Input[] { new GENN.Input () };
		}

		[Test ()]
		public void TestInputArrayConstructorSetsInputs ()
		{
			GENN.Neuron neuron = new GENN.Neuron (inputs);
			Assert.AreEqual (inputs, neuron.Inputs);
		}

		[Test ()]
		public void TestInputArrayConstructorSetsWeights ()
		{
			GENN.Neuron neuron = new GENN.Neuron (inputs);
			Assert.IsNotNull (neuron.Weights);
		}

		[Test ()]
		public void TestInputArrayConstructorSetsBias ()
		{
			GENN.Neuron neuron = new GENN.Neuron (inputs);
			Assert.IsNotNull (neuron.Bias);
		}

		[Test ()]
		public void TestNeuronArrayConstructorSetsInputs ()
		{
			GENN.Neuron[] neurons_0 = new GENN.Neuron[] { new GENN.Neuron (inputs) };
			GENN.Neuron neuron = new GENN.Neuron (neurons_0) ;
			Assert.AreEqual (neurons_0, neuron.Inputs);
		}

		[Test ()]
		public void TestNeuronArrayConstructorSetsWeights ()
		{
			GENN.Neuron[] neurons_0 = new GENN.Neuron[] { new GENN.Neuron (inputs) };
			GENN.Neuron neuron = new GENN.Neuron (neurons_0);
			Assert.IsNotNull (neuron.Weights);
		}

		[Test ()]
		public void TestNeuronArrayConstructorSetsBias ()
		{
			GENN.Neuron[] neurons_0 = new GENN.Neuron[] { new GENN.Neuron (inputs) };
			GENN.Neuron neuron = new GENN.Neuron (neurons_0);
			Assert.IsNotNull (neuron.Bias);
		}

		[Test ()]
		public void TestNeuronBreedingConstructorSetsInputs ()
		{
			GENN.Neuron female_neuron = new GENN.Neuron (inputs);
			GENN.Neuron male_neuron = new GENN.Neuron (inputs);
			GENN.Neuron child_neuron = new GENN.Neuron (female_neuron, male_neuron);
			Assert.AreEqual (female_neuron.Inputs, child_neuron.Inputs);
		}

		[Test ()]
		public void TestNeuronBreedingConstructorSetsWeights ()
		{
			GENN.Neuron female_neuron = new GENN.Neuron (inputs);
			GENN.Neuron male_neuron = new GENN.Neuron (inputs);
			GENN.Neuron child_neuron = new GENN.Neuron (female_neuron, male_neuron);
			Assert.IsNotNull (child_neuron.Weights);
		}

		[Test ()]
		public void TestNeuronBreedingConstructorSetsBias ()
		{
			GENN.Neuron female_neuron = new GENN.Neuron (inputs);
			GENN.Neuron male_neuron = new GENN.Neuron (inputs);
			GENN.Neuron child_neuron = new GENN.Neuron (female_neuron, male_neuron);
			Assert.IsNotNull (child_neuron.Bias);
		}

		[Test()]
		public void TestOutput ()
		{
			GENN.Neuron neuron = new GENN.Neuron (inputs);
			Assert.IsNotNull (neuron.Output); 
		}
	}
}

