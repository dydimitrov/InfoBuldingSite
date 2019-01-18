using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gsg.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace gsg.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IApartmentService service;

        public PropertyController(IApartmentService service)
        {
            this.service = service;
        }
        public IActionResult AllApartments(string section)
        {
            var model = this.service.AllBySection(section);
            return View(model);
        }

        public IActionResult AllGarages(string section)
        {
            var model = this.service.AllGaragesBySection(section);
            return View(model);
        }
    }
}