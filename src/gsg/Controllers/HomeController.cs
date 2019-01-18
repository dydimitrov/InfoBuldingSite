using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gsg.Models;
using gsg.Services.Contract;

namespace gsg.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApartmentService _service;

        public HomeController(IApartmentService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Request model)
        {
            if (this.ModelState.IsValid)
            {
                this._service.CreateRequest(model.Name, model.Email,model.Message);
            }

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult FinishedProjects()
        {
            return View();
        }
    }
}
