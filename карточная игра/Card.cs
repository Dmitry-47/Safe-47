using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace карточная_игра
{
    public class Card
    {
        public string suit { get; set; }
        public string type { get; set; }
        
       public Card()
        {
            
            string [] allSuit ={"6","7","8","9","10","V","D","K","T"};
            string[] allType = {"Hearts", "Diamonds", "Clubs", "Spades"};

            Random rnd = new Random();
            suit = allSuit[rnd.Next(0, allSuit.Length)];
            type= allType[rnd.Next(0, allType.Length)];

            
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object input)
        {
            if(input is Card && input != null)
            {            
                if(this.ToString()==input.ToString())
                    return true;
            }
            return false;
        }

        public static bool operator ==(Card one, Card two)
        {
            if (one.suit == two.suit && one.type == two.type)
            {
                return true;
            }
            else
                return false;
        }

        public static bool operator !=(Card one, Card two)
        {
            if (one == two)
                return false;
            else
                return true;
        }
       

        public override string ToString()
        {
            return $"{suit}\n{type}";
        }
        public static bool operator >(Card one, Card two)
        {

            if (IndexOf(one) > IndexOf(two))
                return true;
            else
                return false;
        }
        public static bool operator <(Card one, Card two)
        {

            if (one>two)
                return false;
            else
                return true;
        }
        public static bool operator >=(Card one, Card two)
        {

            if (IndexOf(one) >= IndexOf(two))
                return true;
            else
                return false;
        }
        public static bool operator <=(Card one, Card two)
        {

            if (IndexOf(one) <= IndexOf(two))
                return true;
            else
                return false;
        }

        private static int IndexOf(Card one)
        {
            string[] allSuit = { "6", "7", "8", "9", "10", "V", "D", "K", "T" };
            for (int i = 0; i < allSuit.Length; i++)
            {
                if (one.suit == allSuit[i])
                    return i;
            }
            return 0;
        }
    }
}
