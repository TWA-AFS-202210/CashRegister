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
			Mock<Purchase> stubPurchase = new Mock<Purchase>();
			stubPurchase.Setup(_ => _.AsString()).Returns("Moq stub content");
			//when
			cashRegister.Process(stubPurchase.Object);
			//then
			printer.Verify(_ => _.Print("Moq stub content"));
		}

		[Fact]
		public void Should_throw_exception_when_printer_is_out_of_paper()
		{
			//given
			Mock<Printer> printer = new Mock<Printer>();
			var cashRegister = new CashRegister(printer.Object);
			var purchase = new Purchase();
			printer.Setup(_ => _.Print(It.IsAny<string>()))
				.Throws<PrinterOutOfPaperException>();
			//when
			//then
			Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
		}
	}
}
