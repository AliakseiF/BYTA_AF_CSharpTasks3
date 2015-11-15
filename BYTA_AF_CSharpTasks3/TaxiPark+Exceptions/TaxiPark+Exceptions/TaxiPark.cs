using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaxiPark
{
    public class TaxiPark
    {
        static void Main(string[] args)
        {
            TaxiParkCars taxiPark = new TaxiParkCars();
            try
            {
                //bin File read/write
                taxiPark.SerializationTest();
                taxiPark.ParkTotalprice();
                taxiPark.OrderCarsByfuelConsumption();
            }
            //custom Exception 1
            catch (EmptyListException ex) { Console.WriteLine(ex.Message);}
            //Exception 1
            catch (ArgumentNullException ex) { Console.WriteLine(ex.Message);}
            try
            {
                //txt File write
                taxiPark.FindCarByParametersAndSaveResult();
            }
            catch(NullReferenceException ex) { Console.WriteLine(ex.Message);}
            //custom Exception 2
            catch (NoColorException ex) { Console.WriteLine(ex.Message); }
            //Exception 2
            catch (FormatException ex) { Console.WriteLine(ex.Message);}
            //custom Exception 3
            catch (NoCarException ex) { Console.WriteLine(ex.Message); }
            try
            {
                //txt File read
                taxiPark.ImportCarsFromFile();
            }
            //Exception 3
            catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
