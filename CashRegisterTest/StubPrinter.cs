using System.Collections.Generic;

namespace CashRegisterTest
{
	using CashRegister;

	public class StubPrinter : Printer
	{
		public override void Print(string content)
		{
			throw new PrinterOutOfPaperException();
		}
	}
}
