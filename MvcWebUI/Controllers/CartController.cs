using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {

        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;


        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;

        }
        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key: "cart");

            _cartService.AddToCart(cart, product);
            _cartSessionHelper.SetCart(key: "cart", cart);


            TempData.Add("message", product.ProductName + "Sepete Eklendi!");

            return RedirectToAction("Index", controllerName: "Product");


        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                cart = _cartSessionHelper.GetCart(key: "cart")
            };
            return View(model);

        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart(key: "cart");
            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart(key: "cart", cart);

            TempData.Add("message", product.ProductName + "Sepetten silindi!");


            return RedirectToAction("Index", controllerName: "Cart");

        }

        public IActionResult Complete()
        {

            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            TempData.Add("message", "Siparişiniz Başarıyla Tamamlandı");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", controllerName:"Cart");
        }

    }
}
