﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;


namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        public ProductsController(IProductsService productsService,
            ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
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

        [HttpGet] //the get method which will load the page with blank fields
        public IActionResult Create()
        {
            var catList = _categoriesService.GetCategories();

            ViewBag.Categories = catList;

            return View(); //model => ProductViewModel
        }

        [HttpPost] //the post method is called when the user clicks on the submit button
        public IActionResult Create(ProductViewModel data, IFormFile file)
        {
            //validation
            try
            {
                if(file != null)
                {
                    if(file.Length > 0)
                    {
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                        //C:\Users\Ryan\source\repos\SWD62AEP\SWD62AEP\SWD62AEP\Presentation\wwwroot
                        string absolutePath = _env.WebRootPath + @"\Images\";

                        using (var stream = System.IO.File.Create(absolutePath + newFilename))
                        {
                            file.CopyTo(stream);
                        }
                        data.ImageUrl = @"\Images\" + newFilename; //relative Path
                    }
                }
                _productsService.AddProduct(data);
                ViewData["feedback"] = "Product was added successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                //log errors
                ViewData["warning"] = "Product was not added. Check your details";
            }
            var catList = _categoriesService.GetCategories();
            ViewBag.Categories = catList;

            return View();
        }


        public IActionResult Delete(Guid id)
        {
            _productsService.DeleteProduct(id);
            TempData["feedback"] = "Product was deleted successfully"; //change wherever we are using ViewData to use TempData data
            return RedirectToAction("Index");
        }


    }
}
