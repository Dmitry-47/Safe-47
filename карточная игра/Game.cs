using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace карточная_игра
{
    public class Game
    {
        public Card[] Deck= new Card[36];


        public Game()
        {
            ShuffleCards(Deck);
           
        }

        public void ShuffleCards(Card[] Deck)
        {
            int i = 0;
            while (i < 36)
            {
                Card one = new Card();
                Deck[i] = one;
                i++;

            }
            i = 0;
            while (i < 35)
            {
                Card one = new Card();
                if (DeckTest(one) == true)
                {
                    Deck[i] = one;
                    i++;
                }
            }          
        }

        private bool DeckTest(Card one)
        {
            for (int i = 0; i < Deck.Length; i++)
            {
               if (Deck[i] == one)
                    return false;  
            }
                                  
            
            return true;
        }

        public void Distribution(Player Player1, Player Player2)
        {
            for (int i = 0; i < Deck.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Player1.PlayerDeck.Add(Deck[i]);
                }
                else
                {
                    Player2.PlayerDeck.Add(Deck[i]);
                }
            }
        }


        public void ShowDeck()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            for (int i = 0; i < 36; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(Deck[i]);
            }
        }
       

    }
}
