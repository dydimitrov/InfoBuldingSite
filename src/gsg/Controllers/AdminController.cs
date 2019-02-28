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
            this.apartments.Create(model.Number,model.Floor,model.Description,model.Area,model.Building);
            return RedirectToAction("All");
        }
        
        public IActionResult CreateGarage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGarage(Garage model)
        {
            this.apartments.CreateGarage(model.Number,model.Floor,model.Description,model.Area,model.Building);
            return RedirectToAction("AllGarages");
        }

        public IActionResult AllGarages()
        {
            var model = this.apartments.AllGarages().OrderBy(x => x.Number).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Sold(int id)
        {
            this.apartments.Sold(id);
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult SetFree(int id)
        {
            this.apartments.SetFree(id);
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.apartments.Delete(id);
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult SoldGarage(int id)
        {
            this.apartments.SoldGarage(id);
            return this.RedirectToAction("AllGarages");
        }

        [HttpPost]
        public IActionResult DeleteGarage(int id)
        {
            this.apartments.DeleteGarage(id);
            return this.RedirectToAction("AllGarages");
        }

        [HttpPost]
        public IActionResult DeleteRequest(Guid id)
        {
            this.apartments.DeleteRequest(id);
            return this.RedirectToAction("AllRequests");
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            var list = apartments.All().OrderBy(x => x.Number).ToList();
            return this.View(list);
        }
        
        public IActionResult AllRequests()
        {
            var list = apartments.AllRequests();
            return this.View(list);
        }
    }
}