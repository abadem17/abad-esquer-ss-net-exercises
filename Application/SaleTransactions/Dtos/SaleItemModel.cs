using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaleTransactions.Dtos
{
	public class SaleItemModel
	{
		public Guid Id { get; set; }
		public decimal Quantity { get; set; }
	}
}
