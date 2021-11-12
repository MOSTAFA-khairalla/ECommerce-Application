using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Model.Entites
{
    public class Featured_Product
    {
        public int ID { get; set; }
        public string ImageFeatured { get; set; }
        public string Des { get; set; }
        public Decimal Price { get; set; }
    }
}
