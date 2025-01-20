using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebStock.Models.ViewModels;
using WebStock.Service;

namespace WebStock.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "id not provided!" });
            }

            var obj = await _productService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "id not found!" });
            }

            return View(obj);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View();
        }
    }
}
