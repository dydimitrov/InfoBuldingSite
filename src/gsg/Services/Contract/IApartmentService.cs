﻿using System.Collections.Generic;
using gsg.Models;

namespace gsg.Services.Contract
{
    public interface IApartmentService
    {
        void Create(int number, string description, double area, Building building);

        List<Apartment> All();
    }
}