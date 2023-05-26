using FluentValidation;

namespace Application.SaleTransactions.Commands
{
	public class PerformSaleCommandValidator : AbstractValidator<PerformSaleCommand>
	{
		public PerformSaleCommandValidator()
		{
			RuleFor(x => x.Items).NotNull().NotEmpty();
			RuleForEach(x => x.Items).ChildRules(item =>
			{
				item.RuleFor(x => x.Id).NotNull().NotEmpty();
				item.RuleFor(x => x.Quantity).GreaterThan(0);
			});
		}
	}
}