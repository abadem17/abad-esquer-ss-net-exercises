using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Page<T> where T : class
	{
		public long Total { get; set; }
		public long CurrentPage { get; set; }
		public int ItemsPerPage { get; set; }
		public List<T> Items { get; set;} = new List<T>();
	}
}
