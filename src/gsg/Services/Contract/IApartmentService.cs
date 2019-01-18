using System.Collections.Generic;
using gsg.Models;

namespace gsg.Services.Contract
{
    public interface IApartmentService
    {
        void Create(int number, int floor, string description, double area, Building building);

        List<Apartment> All();

        List<Apartment> AllBySection(string section);

        void CreateRequest(string name, string email, string message);
    }
}