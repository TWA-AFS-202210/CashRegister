namespace CashRegisterTest
{
	using CashRegister;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
			SpyPrinter printer = new SpyPrinter();
			var cashRegister = new CashRegister(printer);
			var stubPurchase = new StubPurchase();
			//when
			cashRegister.Process(stubPurchase);
			//then
			Assert.True(printer.HasPrinted);
			Assert.Equal("stub content", printer.PrintContent);
		}

		[Fact]
		public void Should_throw_HardwareException_when_process_given_stub_printer_throw_out_of_paper_exception()
		{
			// given
			StubPrinter printer = new StubPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			// when
			// then
			HardwareException hardwareException = Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
			Assert.Equal("Printer is out of paper.", hardwareException.Message);
		}
	}
}
