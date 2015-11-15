using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiPark.CarHierarchy.CarClasses.Business.Models;
using TaxiPark.CarHierarchy.CarClasses.Comfort.Models;
using TaxiPark.CarHierarchy.CarClasses.Econom.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace TaxiPark
{
    public class TaxiParkCars
    {
        string inputStr;
        string carFile = Directory.GetCurrentDirectory() + "\\carFile.dat";
        string carFile2 = Directory.GetCurrentDirectory() + "\\carFile.txt";

        private List<Car> CarList;
        private List<Car> results;

        private List<Car> CarList1 = new List<Car>
        {
            new BMW("750", "Black", "Sedan", 30000, 11, 25, 0001),
            new BMW("X5","White","SUV",37000,13, 27, 0002),
            new BMW("530d","Black","Sedan",25000,10, 25, 0003),
            new Mercedes("S500","Black","Sedan",40000,14, 30, 0004),
            new Mercedes("E300","Blue","Sedan",25000,12,25,0005),
            new Audi("A6","Grey","Wagon",20000,12,20,0006),
            new Audi("A4","Grey","Sedan",19000,11,19,0007),
            new VW("Passat","Black","Wagon",18000,9,20,0008),
            new Ford("Focus","Yellow","Hatch",12000,9,15,0009),
            new Hyundai("Solaris","Yellow","Sedan",10000,8,13,0010)
        };

        public void ExportCarsToFile()
        {
            if (File.Exists(carFile2)) File.Delete(carFile2);
            using (FileStream fs = new FileStream(carFile2, FileMode.Create, FileAccess.Write))
                try
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    foreach (Car c in results)
                    {
                    sw.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                    c.carColor, c.carType, c.carPrice, c.carFuelConsumption, c.carRate, c.carNumber);
                    }
                }
                //Exception 4
                catch (IOException)
                {
                    Console.WriteLine("File error");
                }
        }

        public void ImportCarsFromFile()
        {
            using (FileStream fs = new FileStream(carFile2, FileMode.Open, FileAccess.Read))
            try
            {
            using (StreamReader sr = new StreamReader(fs))
            inputStr = sr.ReadToEnd();
            Console.WriteLine("\n Cars from the latest successfully saved results file" + inputStr);
            }
            catch (IOException)
            {
            Console.WriteLine("File error");
            }
        }

        public void SerializationTest()
        {
            if (File.Exists(carFile)) File.Delete(carFile);
            if (CarList1.Count == 0)
            {
                var EmptyListEx = new EmptyListException("TaxiPark is epmty :(")
                {};
                throw EmptyListEx;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(carFile, FileMode.Create))
            {
                formatter.Serialize(fs, CarList1);
                Console.WriteLine("CarList is serialized");
                Console.ReadLine();
            }
            using (FileStream fs = new FileStream(carFile, FileMode.Open))
            {
                CarList = (List<Car>)formatter.Deserialize(fs);
                DisplayResults(CarList, "Deserialized cars from saved file:");
                Console.ReadLine();
            }
        }

        public void ParkTotalprice()
        {
            int carCount = CarList.Count();
            int totalprice = CarList.Sum(car => car.carPrice);
            Console.WriteLine("\nTaxi Park consists of {0} cars", carCount);
            Console.WriteLine("Total price of all the cars: {0} $", totalprice);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void OrderCarsByfuelConsumption()
        {
            Console.WriteLine("\nCars from TaxiPark ordered by Fuel Consumption: \n");
            var orderedCars = CarList.OrderBy(car => car.carFuelConsumption);
            foreach (var car in orderedCars)
            {
                Console.WriteLine("Car int. number: {0}, Fuel Consumption: {1} litres/100km", car.carNumber, car.carFuelConsumption);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void FindCarByParametersAndSaveResult()
        {
            //TODO: find by subclasses params & show result with this params
            Console.WriteLine("\nPlease enter car color or press [Enter] to skip this step");
            string color = Console.ReadLine();
            if (CarList.FindAll(c => (c.carColor == color || color == "")).Count == 0)
            {
                var noColorEx = new NoColorException("Car with " + color + " color not found in TaxiPark")
                {
                    NoColorName = color
                };
                throw noColorEx;
            }
            Console.WriteLine("Please enter car type or press [Enter] to skip this step");
            string carType = Console.ReadLine();
            Console.WriteLine("Please enter car price or '0' to skip this step");
            int price = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter car fuel consumption or '0' to skip this step");
            int fuelConsumption = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter car rate or '0' to skip this step");
            int carRate = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter car number or '0' to skip this step");
            int number = Int32.Parse(Console.ReadLine());
            GenerateResults(color, carType, price, fuelConsumption, carRate, number);
        }

        private void GenerateResults(string color, string carType, int price, int fuelConsumption, int carRate,
            int number)
        {
            results = CarList.FindAll(c =>
            (c.carColor == color || color == "")
            && (c.carType == carType || carType == "")
            && (c.carPrice == price || price == 0)
            && (c.carFuelConsumption == fuelConsumption || fuelConsumption == 0)
            && (c.carRate == carRate || carRate == 0)
            && (c.carNumber == number || number == 0));
            if (results.Count == 0)
            {
                var noCarEx = new NoCarException("Car with entered parameters not found in TaxiPark")
                {
                };
                throw noCarEx;
            }
            else
            {
                ExportCarsToFile();
                DisplayResults(results, "The following cars match your parameters: " + "\n(color, type, price, consumption, rate, number");
            }
            Console.ReadLine();
        }

        private void DisplayResults(List<Car> result, string title)
        {
            Console.WriteLine("\n" + title);
            foreach (Car c in result)
            {
                Console.Write("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                    c.carColor, c.carType, c.carPrice, c.carFuelConsumption, c.carRate, c.carNumber);
            }
        }
    }
}
