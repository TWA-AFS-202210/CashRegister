using System.Collections.Generic;

namespace CashRegisterTest
{
	using CashRegister;

	public class SpyPrinter : Printer
	{
		public bool HasPrinted { get; set; }
		public string ContentPrinted { get; set; }

		public override void Print(string content)
		{
			ContentPrinted = content;
			// send message to a real printer
			base.Print(content);
			HasPrinted = true;
		}
	}
}
