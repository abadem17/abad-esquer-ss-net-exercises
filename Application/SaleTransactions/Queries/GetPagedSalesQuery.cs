﻿using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Common.Domain;

namespace Application.SaleTransactions.Queries
{
    public class GetPagedSalesQuery : IQuery<Page<SaleInfoModel>>, IPageRequest
    {
        public int ItemsPerPage { get; set; }
        public long CurrentPage { get; set; }

        public GetPagedSalesQuery() { }

        public GetPagedSalesQuery(int itemsPerPage, long currentPage)
        {
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
        }
    }
}
