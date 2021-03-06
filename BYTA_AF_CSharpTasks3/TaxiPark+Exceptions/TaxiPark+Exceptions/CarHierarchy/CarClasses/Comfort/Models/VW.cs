﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.CarHierarchy.CarClasses.Comfort.Models
{
    [Serializable]
    public class VW : global::TaxiPark.CarClasses.Comfort
    {
        public VW(string model, string color, string type, int price, int consumption, int rate, int number, string carclass = "Comfort", string manufacturer = "VW") : base(color, type, price, consumption, rate, number, carclass)
        {
            this.carModel = model;
            this.carManufacturer = manufacturer;
        }

        public string carModel { get; private set; }
        public string carManufacturer { get; private set; }
    }
}
