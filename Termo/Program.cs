using System;
using System.IO;
namespace Termo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nOlá, este jogo se chama 'Termo', uma cópia descarada sem fins lucrativos do famoso jogo da web!\n\n\n" +
                "Uma palavra será sorteada contém só 5 letras e você terá que escrever até acertar! Ou dar Alt + F4 :(\n\n" +
                "Caso apereça a letra que você digitou na saída, significa que você acertou:)\n\n" +
                "Caso apareça uma interrogação ao invés da letra digitada na saídá, significa que você errou a letra:(\n\n");
            Console.WriteLine("Pressione 'Enter' para começar...");
            Console.ReadLine();
            Console.Clear();
            string continuar = "";
            do
            {
                string palavraSorteada = Sorteio(Lista());
                string palavraResultado = "";
                Console.WriteLine("Digite a palavra...");
                do
                {
                    string palavraEscolhida = VerificaEntrada();
                    palavraResultado = Match(palavraSorteada, palavraEscolhida);
                    Console.WriteLine(palavraResultado);
                } while (!Ultimato(palavraSorteada, palavraResultado));
                Console.Clear();
                Console.WriteLine("Parabéns!!!\nClap!\nClap!\nClap!\nVocê quer continuar? (S/N)");
                continuar = Console.ReadLine();
            } while (continuar == "S");
            Console.ReadLine();
        }
        static string Sorteio(string[] times)
        {
            var rnd = new Random();
            var r = rnd.Next(times.Length);
            return ((string)times[r]);
        }
        static string VerificaEntrada()
        {
            string palavraEscolhida = "";
            do
            {
                palavraEscolhida = Console.ReadLine();
            } while (palavraEscolhida.Length != 5);
            return palavraEscolhida;
        }
        static string Match(string palavraSorteada, string palavraEscolhida)
        {
            string palavraResultante = "";
            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                if (palavraSorteada[i] == palavraEscolhida[i])
                {
                    palavraResultante+=palavraSorteada[i];
                }
                else
                {
                    palavraResultante += "?";
                }
            }
            return palavraResultante;
        }
        static bool Ultimato(string palavraSorteada, string palavraResultante)
        {
            return palavraSorteada == palavraResultante;
        }
        static string[] Lista()
        {
            string[] lista = File.ReadAllLines("C:\\Users\\lukes\\source\\repos\\Termo\\Termo\\Words.txt");
            return lista;
        }
    }
}
