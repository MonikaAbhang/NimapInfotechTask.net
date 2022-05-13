using Microsoft.AspNetCore.Mvc;
using NipamInfotechTask.Models;
using System;

namespace NipamInfotechTask.Controllers
{
    public class ProductsController : Controller
    {
        private const string _connectionString =
         @"Data Source=WL-5PFXVG3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        ProductServices _productService = new ProductServices();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                _productService.Insert(product);
            }
            catch (Exception e)
            {
                TempData["success-msg"] = "Invalid Product Information!!";
            }
            //TempData["success-msg"] = "User has been successfully created!!";
            ViewBag.Showmsg = "Data Added SuccesFully #128285 ";
           
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var product = _productService.GetAllProduct().Where(s => s.ProductId == productId).FirstOrDefault();
            return View(product);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            _productService.Edit(product);
            TempData["success-msg"] = "Product has been successfully updated!!";
            return RedirectToAction("Index");
        }

        // Get
        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ViewDetail(int productId)
        {
            var product = _productService.GetAllProduct().Where(s => s.ProductId == productId).FirstOrDefault();
            return View(product);
        }

    }
}
