using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace GENNTests
{
	[TestFixture ()]
	public class TestInput
	{
		[Test ()]
		public void TestInputRandomConstructorSetsOutput ()
		{
			GENN.Input input = new GENN.Input ();
			Assert.IsNotNull (input.Output);
		}

		[Test ()]
		public void TestInputRandomConstructorSetsOutputGreaterThanZero ()
		{
			GENN.Input input = new GENN.Input ();
			Assert.Greater(input.Output, 0);
		}

		[Test ()]
		public void TestInputRandomConstructorSetsOutputLessThanOne ()
		{
			GENN.Input input = new GENN.Input ();
			Assert.Less (input.Output, 1);
		}

		[Test ()]
		public void TestInputExplicitConstructorSetsOutput ()
		{
			Random rand = new Random ();
			double expected = rand.NextDouble ();
			GENN.Input input = new GENN.Input (expected);
			Assert.AreEqual (expected, input.Output);
		}
	}
}

