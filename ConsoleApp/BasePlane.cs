using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BasePlane
    {
        public BasePlane(string number, Airport currentAirport)
        {
            Number = number;
            CurrentAirport = currentAirport;
            Postion = new Postion(currentAirport.Postion.X, currentAirport.Postion.Y);
        }
      
        public string Number { get; }

        public Airport CurrentAirport { private set; get; }

        public Postion Postion { get; }

        public event EventHandler Departure;

        public event EventHandler Arrive;

        public void Fly(Airport endPoint)
        {
            Departure += CurrentAirport.DepturePlane;
            Departure(this, null);
            Departure -= CurrentAirport.DepturePlane;
            while ((Postion.X > endPoint.Postion.X + 1 || Postion.Y > endPoint.Postion.Y + 1) || (Postion.X < endPoint.Postion.X - 1 || Postion.Y < endPoint.Postion.Y - 1))
            {
                if (Postion.Y > endPoint.Postion.Y)
                {
                    Postion.Y--;
                }
                else if (Postion.Y < endPoint.Postion.Y)
                {
                    Postion.Y++;
                }

                if (Postion.X > endPoint.Postion.X)
                {
                    Postion.X--;
                }
                else if (Postion.X < endPoint.Postion.X)
                {
                    Postion.X++;
                }

                Console.SetCursorPosition(Postion.X, Postion.Y);
                Console.Write("|");
                Thread.Sleep(100);
                Console.Clear();
                CurrentAirport.DrawAirpotPostion();
                endPoint.DrawAirpotPostion();
            }
            CurrentAirport = endPoint;
            Arrive += endPoint.ArrivePlane;
            Arrive(this, null);
            Arrive -= endPoint.ArrivePlane;
        }   
    }
}