using NUnit.Framework;
using System;
using GENN;
using NUnit.Framework.Constraints;

namespace GENNTests
{
	[TestFixture ()]
	public class TestInput
	{
		[Test ()]
		public void TestInputRandomConstructorSetsOutput ()
		{
			GENN.Input input = new Input ();
			Assert.IsNotNull (input.Output);
		}

		[Test ()]
		public void TestInputRandomConstructorSetsOutputGreaterThanZero ()
		{
			GENN.Input input = new Input ();
			Assert.Greater(input.Output, 0);
		}

		[Test ()]
		public void TestInputRandomConstructorSetsOutputLessThanOne ()
		{
			GENN.Input input = new Input ();
			Assert.Less (input.Output, 1);
		}

		[Test ()]
		public void TestInputExplicitConstructorSetsOutput ()
		{
			Random rand = new Random ();
			double expected = rand.NextDouble ();
			GENN.Input input = new Input (expected);
			Assert.AreEqual (expected, input.Output);
		}
	}
}

