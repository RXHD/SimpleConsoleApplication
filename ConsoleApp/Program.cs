using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void Clear()
        {
            int i = 2;
            Console.SetCursorPosition(47, 2);
            while (i != 10)
            {
                Console.SetCursorPosition(47, i);
                Console.Write(new string(' ', 52));
                i++;
            }
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Map map = new Map();
            Menu menu = new Menu();
            List<Airport> airports = new List<Airport>() {
              new Airport("AIR 1", new Postion(2, 3)),
              new Airport("AIR 2", new Postion(20, 15)),
              new Airport("AIR 3", new Postion(10, 30))
            };

            var airportData = airports.SingleOrDefault(airport => airport.Name == "AIR 1");
            airportData.AddPlane(new BasePlane($"A{rnd.Next(300, 900)}", airportData));

            while (true)
            {
                map.Draw();
                menu.Draw();
           
                airports.ForEach(airport => airport.DrawAirpotPostion());
                Console.SetCursorPosition(47, 2);
                Console.Write("Select start airport: ");
                foreach (var airport in airports)
                {
                    Console.Write($"{airport.Name} ");
                }
                Console.SetCursorPosition(47, 3);
                var selectedAirportName = Console.ReadLine();
                var selectedAirport = airports.Where(airport => airport.Name == selectedAirportName).SingleOrDefault();
                while (selectedAirport == null)
                {
                    Console.SetCursorPosition(47, 3);
                    Console.WriteLine("Please input correct name of airport");
                    Console.SetCursorPosition(47, 4);
                    selectedAirportName = Console.ReadLine();
                    selectedAirport = airports.Where(airport => airport.Name == selectedAirportName).SingleOrDefault();
                }

                if (selectedAirport.BasePlanes.Count == 0)
                {
                    Clear();
                    Console.SetCursorPosition(47, 2);
                    Console.WriteLine("Airport hasn't planes");
                    Console.ReadKey();
                    continue;
                }
                Clear();

                Console.SetCursorPosition(47, 2);
                Console.Write("Select airplane: ");
                foreach (var plane in selectedAirport.BasePlanes)
                {
                    Console.Write(plane.Number + " ");
                }
             
                Console.SetCursorPosition(47, 3);
                var selectedPlaneName = Console.ReadLine();
                var selectedPlane = selectedAirport.BasePlanes.Where(plane => plane.Number == selectedPlaneName).SingleOrDefault();

                while (selectedPlane == null)
                {
                    Console.SetCursorPosition(47, 3);
                    Console.Write("Please input correct model of airplane");
                    Console.SetCursorPosition(47, 4);
                    selectedPlaneName = Console.ReadLine();
                    selectedPlane = selectedAirport.BasePlanes.Where(plane => plane.Number == selectedPlaneName).SingleOrDefault();
                }
                Clear();
                Console.SetCursorPosition(47, 2);
                Console.Write("Select end airport: ");
                foreach (var endPoint in airports)
                {
                    if (endPoint.Name != selectedPlane.CurrentAirport.Name)
                    {
                        Console.Write(endPoint.Name + " ");
                    }
                }
                Console.SetCursorPosition(47, 3);
                var selectedEndPointName = Console.ReadLine();
                var selectedEndPoint = airports.Where(endPoint => endPoint.Name == selectedEndPointName).SingleOrDefault();

                while (selectedEndPoint == null || selectedEndPoint.Name == selectedPlane.CurrentAirport.Name)
                {
                    Console.SetCursorPosition(47, 3);
                    Console.WriteLine("Please input correct name of airport");
                    Console.SetCursorPosition(47, 4);
                    selectedEndPointName = Console.ReadLine();
                    selectedEndPoint = airports.Where(endPoint => endPoint.Name == selectedEndPointName).SingleOrDefault();
                }
                Clear();
                selectedPlane.Fly(selectedEndPoint);

               
            }
        }
    }
}
