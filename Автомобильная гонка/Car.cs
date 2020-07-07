using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Гонки
{
  
    abstract class Car
    {
        public event DelRace StartEvent = null;
        public void InvokeStartEvent()
        {
           
            StartEvent.Invoke();
           
        }

        public event DelRace GoEvent = null;
        public void InvokeGoEvent()
        {
                GoEvent.Invoke();
           
        }

        public event DelRaceWin WinEvent = null;
        public void InvokeWinEvent()
        {  
            WinEvent.Invoke();           
        }

        public string name { get; set; }
        public int speed {get; set;}
        public double distance { get; set; }

        public Car()
        {
            name = "name";
            speed = 0;
            distance = 0;
        }
        public Car(string name = "name")
        {
            this.name = name;
            Random rnd = new Random();
            speed = rnd.Next(0,100);
        }
        public abstract void Show();      
        public abstract void Go();
        public abstract bool Win ();
       
    }
}
