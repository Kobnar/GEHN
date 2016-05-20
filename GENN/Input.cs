using System;

namespace GENN
{
	/// <summary>
	/// An input class which provides the basic "Output" value to serve as the first layer in the network
	/// </summary>
	public class Input
	{
		public Input ()
		{
			Random rand = new Random ();
			Output = rand.NextDouble ();
		}

		public Input (double output)
		{
			Output = output;
		}

		public double Value;
		public double Output;
	}
}

