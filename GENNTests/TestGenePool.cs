using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace GENNTests
{
	[TestFixture ()]
	public class TestGenePool
	{
		GENN.Input[] inputs;

		[SetUp ()]
		public void Init()
		{
			// Create the basic inputs layer
			inputs = new GENN.Input[] { new GENN.Input () };
		}

		[Test ()]
		public void TestGetSetInput ()
		{
			GENN.GenePool pool = new GENN.GenePool (inputs, 0, 0, new int[] { 0 });
			double[] expected = new double[] { 2.3 };
			pool.Input = expected;
			Assert.AreEqual (expected, pool.Input);
		}
	}
}

