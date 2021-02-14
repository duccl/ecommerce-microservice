using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogs.api.Model
{
    public class CatalogModel
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
