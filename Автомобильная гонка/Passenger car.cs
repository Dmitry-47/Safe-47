using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Гонки
{
    class Passenger_car:Car
    {
        public Passenger_car(string name) : base(name)
        {
            Random rnd = new Random();
            speed = rnd.Next(30, 100);
        }

        public override void Go()
        {

            this.distance = this.distance + this.speed / 3.6;
            Console.WriteLine($"{name} speed car {speed} пройденно {this.distance} м");
            Thread.Sleep(1000);
        }

        public override void Show()
        {
            Console.WriteLine($"на старте name car {name} ");
        }
        public override bool Win()
        {
            if (distance >= 100)
            {
                Console.WriteLine($"Победитель {name}");
                return true;
            }
            else
                return false;
        }
    }
}
