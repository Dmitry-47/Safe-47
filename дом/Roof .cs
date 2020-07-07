using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Roof : IPart
    {

        public string part_of_the_house()
        {
            
            return @"
                    __________________      
                   /\        ______    \    
                  //_\       \    /\    \  
                 //___\       \__/  \    \
                //_____\       \ |[]|     \
               //_______\       \|__|      \
              /XXXXXXXXXX\                  \
             /_I_IIXXI__I_\__________________\
                I_____I_________________I
                I_____I_________________I
                I     I     XXXXXXX     I
             ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
        }
    }
}
