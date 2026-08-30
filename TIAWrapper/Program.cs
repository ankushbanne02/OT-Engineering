using System;
using Microsoft.Owin.Hosting;

namespace TIAWrapper;

public static class Program
{
	public static void Main(string[] args)
	{
		string baseAddress = "http://localhost:5215";

		using (WebApp.Start<Startup>(baseAddress))
		{
			Console.WriteLine("TIAWrapper API running at " + baseAddress);
			Console.WriteLine("Press Enter to stop...");
			Console.ReadLine();
		}
	}
}