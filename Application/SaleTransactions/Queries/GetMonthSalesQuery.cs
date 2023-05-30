﻿using Application.SaleTransactions.Dtos;
using Common.CQRS;

namespace Application.SaleTransactions.Queries
{
	public class GetMonthSalesQuery : IQuery<List<SaleInfoModel>>
	{
		public int Year { get; set; }
	}
}