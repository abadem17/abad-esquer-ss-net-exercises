using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaleTransactions.Queries
{
	public class GetPagedSalesQueryHandler : IQueryHandler<GetPagedSalesQuery, Page<SaleInfoModel>>
	{
		public Task<Page<SaleInfoModel>> Handle(GetPagedSalesQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
