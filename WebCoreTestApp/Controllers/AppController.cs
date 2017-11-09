﻿using Microsoft.AspNetCore.Mvc;
using WebCoreTestApp.ViewModels;

namespace WebCoreTestApp.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

            }

            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
