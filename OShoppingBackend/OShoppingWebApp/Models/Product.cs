using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OShoppingWebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductPrice { get; set; }
        public string ProductAvailability { get; set; }

    }
}
