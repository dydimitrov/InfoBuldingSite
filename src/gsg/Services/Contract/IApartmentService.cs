using System;
using System.Collections.Generic;
using gsg.Models;

namespace gsg.Services.Contract
{
    public interface IApartmentService
    {
        void Create(int number, int floor, string description, double area, Building building);

        void CreateGarage(int number, int floor, string description, double area, Building building);

        List<Apartment> All();

        List<Garage> AllGarages();

        List<Request> AllRequests();

        List<Apartment> AllBySection(string section);

        List<Garage> AllGaragesBySection(string section);

        void CreateRequest(string name, string email, string message);

        void DeleteRequest(Guid id);

        void Sold(int id);

        void SetFree(int id);

        void SoldGarage(int id);

        void SetFreeGarage(int id);

        void Delete(int id);

        void DeleteGarage(int id);
    }
}