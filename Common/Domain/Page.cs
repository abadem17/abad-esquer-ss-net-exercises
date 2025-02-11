using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Page<T> where T : class
    {
        public List<T> Items { get; set; }  // Ahora maneja cualquier tipo genérico
        public long CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public long TotalItems { get; set; }
        public long TotalPages => (long)Math.Ceiling((double)TotalItems / ItemsPerPage);

        public Page(List<T> items, long currentPage, int itemsPerPage, long totalItems)
        {
            Items = items;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}
