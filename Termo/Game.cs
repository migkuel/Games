using System;
using Termo;

namespace Games
{
    interface IGame
    {
        void Run();
        void Exit();
    }
    public class Game
    {
        enum TypeGame
        {
            Termo = 1, 
            Hangman = 2
        }
        static User user;
        static void Main(string[] args)
        {
            Console.WriteLine("   Escreva seu nickname para começar...");
            string aux = Console.ReadLine();
            user = new User(aux);
            UserManager userManager = new UserManager();
            userManager.SaveUser(user);

            Run();
        }
        static void Menu()
        {
            Console.WriteLine("   Digite '1' para jogar o 'Termo' ou " +
                "\n   digite '2' para jogar o 'Jogo da forca'... ");
        }
        public static void Run()
        {
            Menu();
            Console.WriteLine("Score:\n" + user.GetWins() + " wins\n" + user.GetLoses() + " loses");
            TypeGame currentGame = ChooseGame();
            if (currentGame == TypeGame.Termo)
            {
                Termo termo = new Termo();
                termo.Run();
            }
            if (currentGame == TypeGame.Hangman)
            {
                HangmanGame hangmanGame = new HangmanGame();
                hangmanGame.Run();
            }
            Console.ReadLine();
        }
        static TypeGame ChooseGame() 
        {
            int type;
            bool aux = false;
            do
            {
                Console.Write("   ");
                type = int.Parse(Console.ReadLine());
                foreach (TypeGame t in Enum.GetValues(typeof(TypeGame)))
                {
                    if ((int)t == type)
                    {
                        aux = true;
                        break;
                    }
                }

            } while (!aux);
            Console.Clear();
            return (TypeGame)type;
        }
        public static void ImproveScore(bool win, bool lose)
        {
            if (win)
                user.PlusWins();
            else if (lose)
                user.PlusLoses();
        }
    }
}
