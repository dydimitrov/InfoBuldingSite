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

        public void Create(int number, int floor, string description, double area, Building building)
        {
            
            var apartment = new Apartment()
            {
                Number = number,
                Floor = floor,
                Description = description,
                Area = area,
                Building = building
            };

            context.Apartments.Add(apartment);
            context.SaveChanges();
        }

        public void CreateGarage(int number, int floor, string description, double area, Building building)
        {
            
            var garage = new Garage()
            {
                Number = number,
                Floor = floor,
                Description = description,
                Area = area,
                Building = building
            };

            context.Garages.Add(garage);
            context.SaveChanges();
        }

        public List<Apartment> All() => context.Apartments.ToList();

        public List<Garage> AllGarages() => context.Garages.ToList();

        public List<Request> AllRequests() => context.Requests.ToList();

        public List<Apartment> AllBySection(string section) => context.Apartments
            .Where(x => x.Building.ToString().ToLower() == section.ToLower()).ToList();

        public List<Garage> AllGaragesBySection(string section) => context.Garages
            .Where(x => x.Building.ToString().ToLower() == section.ToLower()).ToList();

        public void CreateRequest(string name, string email, string message)
        {
            var request = new Request()
            {
                Email = email,
                Name = name,
                Message = message
            };
            this.context.Requests.Add(request);
            this.context.SaveChanges();
        }

        public void DeleteRequest(Guid id)
        {
            var request = this.context.Requests.FirstOrDefault(x => x.Id == id);

            this.context.Requests.Remove(request);
            this.context.SaveChanges();
        }

        public void Sold(int id)
        {
            var apartment = this.context.Apartments.FirstOrDefault(x => x.Id == id);
            apartment.IsSold = true;

            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var apartment = this.context.Apartments.FirstOrDefault(x => x.Id == id);

            this.context.Apartments.Remove(apartment);
            this.context.SaveChanges();
        }

        public void SoldGarage(int id)
        {
            var garage = this.context.Garages.FirstOrDefault(x => x.Id == id);
            garage.IsSold = true;

            this.context.SaveChanges();
        }

        public void DeleteGarage(int id)
        {
            var garage = this.context.Garages.FirstOrDefault(x => x.Id == id);

            this.context.Garages.Remove(garage);
            this.context.SaveChanges();
        }
    }
}
