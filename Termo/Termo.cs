using System;
using System.IO;

namespace Games
{
    internal class Termo: IGame
    {
        public Termo() { }
        public void Run()
        {
            Introducao();
            Gamee();
        }
        public void Introducao()
        {
            Console.WriteLine("\n   Olá, este jogo se chama 'Termo', uma cópia descarada sem fins lucrativos do famoso jogo da web!\n\n\n" +
                "   Uma palavra será sorteada contém só 5 letras e você terá que escrever até acertar! Ou dar Alt + F4 :(\n\n" +
                "   Caso apereça a letra que você digitou na saída, significa que você acertou:)\n\n" +
                "   Caso apareça uma interrogação ao invés da letra digitada na saídá, significa que você errou a letra:(\n\n" +
                "   Pressione 'Enter' para começar...");
            Console.Write("   ");
            Console.ReadLine();
            Console.Clear();
        }
        public void Gamee()
        {
            string continuar = "";
            do
            {
                int tentativas = 0;
                string[] palavrasDisponiveis = Lista();
                string palavraSorteada = Sorteio(palavrasDisponiveis);
                ConsoleLetter[] palavraResultado = new ConsoleLetter[5];
                Console.WriteLine("   Digite a palavra...");
                do
                {
                    string palavraEscolhida = VerificaEntrada(palavrasDisponiveis);
                    palavraResultado = Match(palavraSorteada, palavraEscolhida);
                    PrintColor(palavraResultado);
                    tentativas++;
                } while (!Ultimato(palavraSorteada, palavraResultado) && tentativas < 9);
                Console.Clear();
                if (tentativas < 8)
                {
                    Console.WriteLine("   Parabéns!!!\n   Clap!\n   Clap!\n   Clap!\n   Você quer continuar? (S/N)");
                    Game.ImproveScore(true, false);
                }
                else
                {
                    Console.WriteLine("   Perdeu");
                    Game.ImproveScore(false, true);
                }
                continuar = Console.ReadLine();
                Console.Clear();
            } while (continuar == "S");
            Exit();
            Console.ReadLine();
        }
        public string Sorteio(string[] times)
        {
            var rnd = new Random();
            var r = rnd.Next(times.Length);
            return ((string)times[r]);
        }
        public string VerificaEntrada(string[] palavrasDisponiveis)
        {
            bool palavraValida = false;
            string palavraEscolhida = "";
            do
            {
                Console.Write("   ");
                palavraEscolhida = Console.ReadLine();
                if (palavraEscolhida.Length < 5 || palavraEscolhida.Length > 5)
                {
                    Console.WriteLine("   Ops! Escreva uma palavra contendo apenas 5 letras...");
                }
                else
                {
                    palavraValida = VericaPalavra(palavrasDisponiveis, palavraEscolhida);
                    if (!palavraValida)
                    {
                        Console.WriteLine("   Ops! Você escreveu uma palavra que não temos em nosso dicionário...");
                    }
                }
            } while (palavraEscolhida.Length != 5 || !palavraValida);
            return palavraEscolhida;
        }
        public bool VericaPalavra(string[] palavrasDisponiveis, string palavraEscolhida)
        {
            bool palavraValida = false;
            for (int i = 0; i < palavrasDisponiveis.Length; i++)
            {
                if (palavrasDisponiveis[i] == palavraEscolhida)
                {
                    palavraValida = true;
                    break;
                }
            }
            return palavraValida;
        }
        public ConsoleLetter[] Match(string palavraSorteada, string palavraEscolhida)
        {
            ConsoleLetter[] palavraResultante = new ConsoleLetter[5];
            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                if (palavraSorteada[i] == palavraEscolhida[i])
                {
                    palavraResultante[i] = new ConsoleLetter();
                    palavraResultante[i].SetLetter(palavraEscolhida[i]);
                    palavraResultante[i].SetColor(ConsoleColor.Green);
                }
                else
                {
                    palavraResultante[i] = new ConsoleLetter();
                    palavraResultante[i].SetLetter(palavraEscolhida[i]);
                    palavraResultante[i].SetColor(ConsoleColor.Red);
                }
            }
            palavraResultante = MatchLetra(palavraResultante, palavraEscolhida, palavraSorteada);
            return palavraResultante;
        }
        public ConsoleLetter[] MatchLetra(ConsoleLetter[] palavraResultante, string palavraEscolhida, string palavraSorteada)
        {
            ConsoleLetter[] palavraResultanteAux = palavraResultante;
            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                for (int j = 0; j < palavraSorteada.Length; j++)
                {
                    if (palavraEscolhida[i] == palavraSorteada[j] && palavraResultanteAux[i].GetColor() == ConsoleColor.Red) 
                    {
                        palavraResultanteAux[i].SetColor(ConsoleColor.Yellow); 
                    }
                }
            }
            return palavraResultanteAux;
        }
        public void PrintColor(ConsoleLetter[] palavraResultante)
        {
            for (int i = 0; i < palavraResultante.Length; i++)
            {
                Console.ForegroundColor = palavraResultante[i].GetColor();
                Console.Write(palavraResultante[i].GetLetter());
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public bool Ultimato(string palavraSorteada, ConsoleLetter[] palavraResultante)
        {
            bool aux = true;
            for (int i = 0; i < palavraResultante.Length; i++)
            {
                if (palavraResultante[i].GetColor() != ConsoleColor.Green)
                {
                    aux = false;
                    break;
                }
            }
            return aux;
        }
        public string[] Lista()
        {
            string[] lista = File.ReadAllLines("C:\\Users\\lukes\\source\\repos\\Termo\\Termo\\Words.txt");
            return lista;
        }
        public void Exit()
        {
            Game.Run();
        }
    }
}
