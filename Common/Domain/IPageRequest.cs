using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public interface IPageRequest
	{
		public int ItemsPerPage { get; set; }
		public long CurrentPage { get; set; }
	}
}
