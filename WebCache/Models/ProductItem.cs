using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCache.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
