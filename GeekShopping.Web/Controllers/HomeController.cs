using GeekShopping.Web.Models;
using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeekShopping.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
        public async Task<IActionResult> Details(long id)
        {
            var product = await _productService.FindProductById(id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Details")]
        public async Task<IActionResult> DetailsPost(ProductViewModel model)
        {

            // Verifica se já existe um UserId na sessão
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                // Gera um novo UserId (pode ser um GUID)
                string newUserId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("UserId", newUserId);
            }

            // Recupera o UserId da sessão
            var userId = HttpContext.Session.GetString("UserId");

            CartViewModel cart =  new()
            {
                CartHeader = new CartHeaderViewModel()
                {
                    UserId = userId
                }
            };

            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                Count = model.Count,
                ProductId = model.Id,
                Product = await _productService.FindProductById(model.Id)
            };

            List<CartDetailViewModel> cartDetails = new List<CartDetailViewModel>();
            cartDetails.Add(cartDetail);
            cart.CartDetails = cartDetails;

            var respose = await _cartService.AddItemToCart(cart);

            if(respose != null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
