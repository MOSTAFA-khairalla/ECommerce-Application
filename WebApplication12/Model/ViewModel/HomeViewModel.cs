using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Model.Entites;

namespace WebApplication12.Model.ViewModel
{
    public class HomeViewModel
    {

        public List<carousel> Carousel { get; set; }
        public List<NewsProduct> NewsProducts { get; set; }
        public List<OldProduct> OldProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<Featured_Product> Featured_Products { get; set; }
    }
}
