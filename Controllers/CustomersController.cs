using Microsoft.AspNetCore.Mvc;
using NipamInfotechTask.Models;
using System;

namespace NipamInfotechTask.Controllers
{
    public class CustomersController : Controller
    {
        private const string _connectionString =
          @"Data Source=WL-5PFXVG3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        CustomerService _customerService = new CustomerServices();
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
        public IActionResult Create(Customer customer)
        {
            try
            {
                _customerService.Insert(customer);
            }
            catch (Exception e)
            {
                TempData["success-msg"] = "Invalid customer Information!!";
            }
            //TempData["success-msg"] = "Customer has been successfully created!!";
            ViewBag.Showmsg = "Data Added SuccesFully #128285 ";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int customerId)
        {
            var customer = _customerService.GetAllCustomer().Where(s => s.CustomerId == customerId).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            _customerService.Edit(customer);
            TempData["success-msg"] = "customer has been successfully updated!!";
            return RedirectToAction("Index");
        }

        // Get
        public IActionResult Delete(int customerId)
        {
            _customerService.Delete(customerId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ViewDetail(int productId)
        {
            var customer = _customerService.GetAllProduct().Where(s => s.CustomerId == customerId).FirstOrDefault();
            return View(customer);
        }

    }
}

