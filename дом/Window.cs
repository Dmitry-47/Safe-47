using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Window : IPart
    {
        public string part_of_the_house()
        {
           return @" 
                    ___________________
                   /\        ______    \    
                  //_\       \    /\    \  
                 //___\       \__/  \    \
                //_____\       \ |[]|     \
               //_______\       \|__|      \
              /XXXXXXXXXX\                  \
             /_I_IIXXI__I_\__________________\ 
               I_I|==I__I_______[__|__]_____I
               I_I|==I__I_______[__|__]_____I
               I I|==I  I       XXXXXXX     I
            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~"; ;
        }
    }
}
