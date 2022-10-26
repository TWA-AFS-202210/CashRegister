using Moq;

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
			Mock<Printer> printer = new Mock<Printer>();
			var cashRegister = new CashRegister(printer.Object);
			var stubPurchase = new StubPurchase();
			//when
			cashRegister.Process(stubPurchase);
			//then
			printer.Verify(_ => _.Print(It.IsAny<string>()));
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
