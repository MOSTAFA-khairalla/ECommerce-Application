using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Model.Entites
{
    public class Product
    {

        public int ID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
}
