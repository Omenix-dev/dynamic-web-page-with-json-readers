using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Ecommerce.ViewModels;
using Ecommerce.Core.IServices;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IProductServices _productServices; 
        public DetailsController(IProductServices productServices)
        {
            _productServices = productServices; 
        }
        public async Task<IActionResult> Index(string ? id)
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                var productDetails = await _productServices.GetProductById(id);
                HomeProductViewModel ViewData = new HomeProductViewModel();
                ViewData.Product = productDetails;
                ViewData.SessionId = HttpContext.Session.GetString("userId");
                ViewData.Email = HttpContext.Session.GetString("userEmail");
                ViewData.FirstSixBestSales = await _productServices.FirstSixBestSales();
                return View(ViewData);
            }
            return RedirectToAction("Login","Auth");
        }
    }
}
