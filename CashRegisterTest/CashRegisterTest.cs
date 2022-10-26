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
	}
}
