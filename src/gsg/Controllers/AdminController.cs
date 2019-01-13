using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gsg.Data;
using gsg.Models;
using gsg.Services;
using gsg.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gsg.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly IApartmentService apartments;

        public AdminController(IApartmentService service)
        {
            apartments = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Apartment model)
        {
            this.apartments.Create(model.Number,model.Description,model.Area,model.Building);
            return RedirectToAction("All");
        }
        

        [HttpPost]
        public IActionResult Edit(Apartment model)
        {
            //TODO add edited apartment to db 
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(Apartment model)
        {
            //TODO delete apartment from db 
            return this.RedirectToAction("All");
        }
        [AllowAnonymous]
        public IActionResult All()
        {
            var list = apartments.All();
            return this.View(list);
        }
    }
}