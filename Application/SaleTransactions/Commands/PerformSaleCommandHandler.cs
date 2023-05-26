using Common.CQRS;
using Common.Exceptions;
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
			var productIds = request.Items.Select(x => x.Id).ToList();
			var productRecords = _repository.Query<Product>().Where(x => productIds.Contains(x.Id)).ToList();
			var transaction = new SaleTransaction
			{
				Date = DateTime.Now,
				Deleted = false,
				PaymentMethodType = request.PaymentMethodType,
				TransactionItems = request.Items.Select(x =>
				{
					var product = productRecords.FirstOrDefault(p => p.Id == x.Id);
					if (product == null)
					{
						throw new HttpBadResquestException("Invalid product");
					}
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