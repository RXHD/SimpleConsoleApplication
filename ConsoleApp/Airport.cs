using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Airport 
    {
        public Airport(string name, Postion postion)
        {
            Name = name;
            Postion = postion;
            BasePlanes = new List<BasePlane>();
        }

        public string Name { get; }
        public Postion Postion { get; }
        public ICollection<BasePlane> BasePlanes { get; }
        
        public void AddPlane(BasePlane plane)
        {
            if (plane != null)
            {
                BasePlanes.Add(plane);
            }
        }

        public void RemovePlane(BasePlane plane)
        {
            if (plane != null)
            {
                BasePlanes.Remove(plane);
            }
        }

        public void ArrivePlane(object sender, EventArgs args)
        {
            if (sender is BasePlane)
            {
               BasePlanes.Add((BasePlane)sender);
            }
        }

        public void DepturePlane(object sender, EventArgs args)
        {
            if (sender is BasePlane)
            {
               BasePlanes.Remove((BasePlane)sender);
            }
        }

        public void DrawAirpotPostion()
        {
            Console.SetCursorPosition(Postion.X, Postion.Y);
            Console.Write($"{Name} P:{BasePlanes.Count}");
        }

      
      
    }
}