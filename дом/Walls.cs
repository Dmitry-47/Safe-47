using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Walls : IPart
    {
        public string part_of_the_house()
        {
            return @"  
                       I_____I_________________I
                       I_____I_________________I
                       I     I     XXXXXXX     I
                    ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
        }
    }
}
