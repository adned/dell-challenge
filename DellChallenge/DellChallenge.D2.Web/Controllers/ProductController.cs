using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;

using Microsoft.AspNetCore.Mvc;
using System;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productsService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DetailsProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productsService.Add(newProduct);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newProduct);
            }
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var product = _productsService.Get(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var product = _productsService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productsService.Update(product.Id, (DetailsProductModel)product);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Update", e.Message);
                    return View(product);
                }
            }
            else
            {
                return View(product);
            }
        }
    }
}