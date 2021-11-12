using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication12.Model.Entites;
using WebApplication12.Model.Interfaces;
using WebApplication12.Model.ViewModel;

namespace WebApplication12.Controllers
{

   
    public class ShopCartController : Controller
    {
        private readonly IUnitOfWork<carousel> _carousel;
        private readonly IUnitOfWork<NewsProduct> _newsProduct;
        private readonly IUnitOfWork<OldProduct> _oldProduct;
        private readonly IUnitOfWork<Product> _product;
        private readonly IUnitOfWork<Featured_Product> _featuresproduct;

        public ShopCartController( IUnitOfWork<carousel> carousel,IUnitOfWork<NewsProduct> NewsProduct ,IUnitOfWork<OldProduct> OldProduct,IUnitOfWork<Product> product,IUnitOfWork<Featured_Product> featuresproduct)
        {
           _carousel = carousel;
            _newsProduct = NewsProduct;
            _oldProduct = OldProduct;
           _product = product;
           _featuresproduct = featuresproduct;
        }
        public IActionResult ShopCart()
        {
            var mm = new HomeViewModel
            {
                Carousel = _carousel.Entity.GetAll().ToList(),
                NewsProducts = _newsProduct.Entity.GetAll().ToList(),
                OldProducts = _oldProduct.Entity.GetAll().ToList(),
                Products = _product.Entity.GetAll().ToList(),
                Featured_Products = _featuresproduct.Entity.GetAll().ToList()
            };
            return View( mm);
        }

     
    }
}
