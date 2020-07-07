using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace карточная_игра
{
   public class Player
    {
        public string Name;
        public List<Card> PlayerDeck;


        public Player(string name)
        {
            Name = name;
            PlayerDeck = new List<Card>();

        }

        public void ShowPlayerDeck()
        {
            int i = 1;
            Console.WriteLine("---------------------------------------------------------------------------");
            foreach (var item in PlayerDeck)
            {
                Console.WriteLine(i);
                Console.WriteLine(item);
                i++;
            }

        }
    }
}
