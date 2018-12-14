using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gsg.Data;
using gsg.Models;
using gsg.Services.Contract;

namespace gsg.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly ApplicationDbContext context;

        public ApartmentService(ApplicationDbContext db)
        {
            context = db;
        }

        public void Create(int number, string description, double area, Building building)
        {
            
            var apartment = new Apartment()
            {
                Number = number,
                Description = description,
                Area = area,
                Building = building
            };

            context.Apartments.Add(apartment);
            context.SaveChanges();
        }

        public List<Apartment> All()
        {
            var apartments = context.Apartments.ToList();
            return apartments;
        }
    }
}
