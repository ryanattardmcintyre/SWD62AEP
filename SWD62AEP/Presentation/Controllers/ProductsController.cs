using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;


namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        /// <summary>
        /// Products Catalogue
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //IQueryable
            //IEnumerable
            //List >>>> IEnumerable >>> IQueryable
            
            var list = _productsService.GetProducts();
            
            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var myProduct = _productsService.GetProduct(id);

            return View(myProduct);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel data)
        {
            //validation
            try
            {
                _productsService.AddProduct(data);

                ViewData["feedback"] = "Product was added successfully";
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //log errors

                ViewData["warning"] = "Product was not added. Check your details";
            }
            
            return View();
        }

    }
}
