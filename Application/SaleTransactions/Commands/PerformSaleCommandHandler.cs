using Common.CQRS;
using Common.Persistence;
using Domain.Entities;

namespace Application.SaleTransactions.Commands
{
	public class PerformSaleCommandHandler : ICommandHandler<PerformSaleCommand>
	{
		private readonly IRepository _repository;

		public PerformSaleCommandHandler(IRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(PerformSaleCommand request, CancellationToken cancellationToken)
		{
			var taxRate = 0.16m;
			var products = new List<Product>();
			var transaction = new SaleTransaction()
			{
				Date = DateTime.Now,
				Deleted = false,
				PaymentMethodType = request.PaymentMethodType,
				TransactionItems = request.Items.Select(x =>
				{
					var product = products.FirstOrDefault(p => p.Id == x.Id);
					return new TransactionItem
					{
						Deleted = false,
						Discount = 0,
						ProductId = x.Id,
						Quantity = x.Quantity,
						Tax = product.UnitPrice * x.Quantity * taxRate,
						UnitPrice = product.UnitPrice,
					};
				}).ToList(),
			};
			_repository.Add(transaction);
			await _repository.SaveChangesAsync(cancellationToken);
		}
	}
}