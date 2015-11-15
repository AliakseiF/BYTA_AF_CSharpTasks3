using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    [Serializable]
    public class Car
    {
        public string carColor { get; private set; }
        public string carType { get; private set; }
        public int carPrice { get; private set; }
        public int carFuelConsumption { get; private set; }
        public int carRate { get; private set; }
        public int carNumber { get; private set; }

        public Car(string color, string type, int price, int consumption, int rate, int number)
        {
            carColor = color;
            carType = type;
            carPrice = price;
            carFuelConsumption = consumption;
            carRate = rate;
            carNumber = number;
        }
    }
}
