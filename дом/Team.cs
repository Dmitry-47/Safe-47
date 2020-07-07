using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Team
    {
        public string result = null;
        public string part_of_the_house_door()
        {
            Door door = new Door();
            return door.part_of_the_house();
        }
        public string part_of_the_house_basement()
        {
            Basement basement = new Basement();
            return basement.part_of_the_house();
        }
        public string part_of_the_house_roof()
        {
            Roof roof = new Roof();
            return roof.part_of_the_house();
        }
        public string part_of_the_house_walls()
        {
            Walls walls = new Walls();
            return walls.part_of_the_house();
        }
        public string part_of_the_house_window()
        {
            Window window = new Window();
            return window.part_of_the_house();
        }

    }
}
