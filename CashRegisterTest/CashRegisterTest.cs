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
			Assert.Equal("stub content", printer.ContentPrinted);
		}

		[Fact]
		public void Should_throw_exception_when_printer_is_out_of_paper()
		{
			//given
			var printer = new StubPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			//then
			Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
		}
	}
}
