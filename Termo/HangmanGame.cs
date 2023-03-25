using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Games
{
    public class HangmanGame: IGame
    {
        public HangmanGame() { }
        public void Run()
        {
            Gamee();
        }
        public void Gamee()
        {
            List<HangmanWord> words = ConvertListToHangWord(Lista());
            HashSet<char> set = new HashSet<char>();
            StringBuilder palavraResultante = new StringBuilder("");
            int choose = 0;
            string palavra = "";
            do
            {
                HangmanWord aux = Sorteio(words);
                palavra = aux.GetWord();
                Console.WriteLine(aux.GetTip());
                palavraResultante.Clear();
                palavraResultante.Insert(0, "-", palavra.Length);
                do
                {
                    Console.WriteLine("Digite uma letra...");
                    char a = Console.ReadLine()[0];
                    if (set.Contains(a))
                        Console.WriteLine("Ops...");
                    else
                        set.Add(a);
                    for (int i = 0; i < palavra.Length; i++)
                    {

                        if (a == palavra[i])
                        {
                            set.Remove(a);
                            palavraResultante[i] = palavra[i];
                        }
                    }
                    foreach (char c in set)
                    {
                        Console.Write(c + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine(palavraResultante);
                } while (palavraResultante.ToString() != palavra && set.Count < 6);
                Console.WriteLine("   Game Over" +
                    "\n   Digite '1' caso queira jogar novamente ou " +
                    "\n   Digite '2' para voltar ao menu...");
                do
                {
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {

                    }
                    if (choose == 2)
                    {
                        Console.WriteLine("   Até logo...");
                        break;
                    }
                } while (choose != 1 && choose != 2);
            } while (choose == 1);
            Exit();
        }
        public string[] Lista()
        {
            string[] lista = File.ReadAllLines("C:\\Users\\lukes\\source\\repos\\Termo\\Termo\\WordsTips.txt");
            return lista;
        }
        private HangmanWord Sorteio(List<HangmanWord> lista)
        {
            var rnd = new Random();
            var r = rnd.Next(lista.Count);
            return (HangmanWord)lista.ElementAt(r);
        }
        List < HangmanWord > ConvertListToHangWord(string[] lista)
        {
            
            List<HangmanWord> hangmanWords = new List<HangmanWord>();
            for (int i = 0; i < lista.Length;i++)
            {
                string[] aux = lista[i].Split(',');
                hangmanWords.Add(new HangmanWord(aux[0], aux[1]));
            }
            return hangmanWords;
        }
        public void Exit()
        {
            Game.Run();
        }
    }
}
