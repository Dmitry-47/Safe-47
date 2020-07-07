using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace карточная_игра
{
    class Program
    {
        static void PlayerMove(Stack<Card> GameTable, Player player)
        {
            Console.WriteLine($"Ходит игрок {player.Name} ");
            try
            {
                try
                {
                    if (GameTable.Peek() > player.PlayerDeck.Last<Card>() && player.PlayerDeck.Count > 0 && GameTable.Count > 0)
                    {
                        Console.WriteLine("Игрок выкладывает карту");
                        Console.WriteLine();
                        GameTable.Push(player.PlayerDeck.Last<Card>());
                        player.PlayerDeck.Remove(player.PlayerDeck.Last<Card>());
                    }
                    else if (GameTable.Peek() <= player.PlayerDeck.Last<Card>() && player.PlayerDeck.Count > 0 && GameTable.Count > 0)
                    {
                        Console.WriteLine("Игрок забирает колоду");
                        Console.WriteLine();
                        player.PlayerDeck.InsertRange(0, GameTable);
                        GameTable.Clear();
                    }

                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Игрок выкладывает карту");
                    Console.WriteLine();

                    GameTable.Push(player.PlayerDeck.Last<Card>());
                    player.PlayerDeck.Remove(player.PlayerDeck.Last<Card>());

                }

            }

            
            catch (InvalidOperationException)
            {
                Console.WriteLine($"У игрока {player.Name} закончилась колода ");
            }


        }

         static bool TestWin(Player player)
        {
            if (player.PlayerDeck.Count == 0)
            {
                Console.WriteLine($"Игрок {player.Name}  проиграл");
                return true;
            }
            else
                return false;
        }

        static void GameTableShow(Player player1, Player player2, Stack<Card> GameTable)
        {
            Console.WriteLine($"{player1.Name}  {player1.PlayerDeck.Count} карт");
            Console.WriteLine();
            try
            {
                Console.WriteLine($" {GameTable.Peek()}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("На столе не осталось карт ");
            }           
            Console.WriteLine();
            Console.WriteLine($"{player2.Name}  {player2.PlayerDeck.Count} карт");
        }
        static void Main(string[] args)
        {
            
            Game game = new Game();
           
            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            game.Distribution(player1, player2);
           
            Stack < Card > GameTable = new Stack<Card>();

            bool testWinPlayer1 = false;
            bool testWinPlayer2 = false;

            while (testWinPlayer1 == false && testWinPlayer2 == false)
            {

                testWinPlayer1 = TestWin(player1);
                if (testWinPlayer1 == false && testWinPlayer2 == false)
                {                   
                    PlayerMove(GameTable, player1);
                
                GameTableShow(player1, player2, GameTable);
                Console.ReadLine();
                Console.Clear();
                }

                testWinPlayer2 = TestWin(player2);
                if (testWinPlayer2 == false && testWinPlayer1 == false)
                {
                    PlayerMove(GameTable, player2);
                    GameTableShow(player1, player2, GameTable);
                    Console.ReadLine();
                    Console.Clear();
                }

               
            }

        }
    }
}
