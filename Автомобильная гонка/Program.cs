using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Гонки
{
    public delegate void DelRace();
    public delegate bool DelRaceWin();
    class Program
    {       
       

        static void Main(string[] args)
        {   Freight_cars freight_car = new Freight_cars("Freight_cars");
            Sports_cars sport_car = new Sports_cars("Sports car");
            Passenger_car passenger_car = new Passenger_car("Passenger_car");
            Bus bus = new Bus("Bus");


            sport_car.StartEvent += sport_car.Show;
            freight_car.StartEvent += freight_car.Show;
            passenger_car.StartEvent += passenger_car.Show;
            bus.StartEvent += bus.Show;

            sport_car.GoEvent += sport_car.Go;
            freight_car.GoEvent += freight_car.Go;
            passenger_car.GoEvent += passenger_car.Go;
            bus.GoEvent += bus.Go;

            sport_car.WinEvent += sport_car.Win;
            freight_car.WinEvent += freight_car.Win;
            passenger_car.WinEvent += passenger_car.Win;
            bus.WinEvent += bus.Win;

            sport_car.InvokeStartEvent();
            freight_car.InvokeStartEvent();
            passenger_car.InvokeStartEvent();
            bus.InvokeStartEvent();
            System.Threading.Thread.Sleep(2000);

            while (sport_car.Win()==false && freight_car.Win()==false && passenger_car.Win()==false && bus.Win()==false)
            {

                sport_car.InvokeGoEvent();
                sport_car.InvokeWinEvent();

                passenger_car.InvokeGoEvent();
                passenger_car.InvokeWinEvent();

                bus.InvokeGoEvent();
                bus.InvokeWinEvent();

                freight_car.InvokeGoEvent();
                freight_car.InvokeWinEvent();
                Console.Clear();
            }

           




            Console.WriteLine();
           
        }
    }
}
