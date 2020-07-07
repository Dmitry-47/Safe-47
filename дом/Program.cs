using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamLeader Shef = new TeamLeader();
            Worker Bob = new Worker();
       
            Bob.Work();
            Bob.Work();
            Shef.team_Leader(Bob);           
            Bob.Work();
            Shef.team_Leader(Bob);








        }
    }
}
