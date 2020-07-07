using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class Door : IPart
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
               I_I|==I__I_________________I
               I_I|==I__I_________________I
               I I|==I  I     XXXXXXX     I
            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~";
        }
    }
}
