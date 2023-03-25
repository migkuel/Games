using System;

namespace Games
{
    internal class ConsoleLetter
    {
        //Atribute
        private char letter;
        private System.ConsoleColor color;
        //Constructor
        public ConsoleLetter(char letter, System.ConsoleColor color)
        {
            this.letter = letter;
            this.color = color;
        }
        public ConsoleLetter()
        {
        }
        //Getters and Setters
        public char GetLetter()
        {
            return letter;
        }
        public ConsoleColor GetColor()
        {
            return color;
        }
        public void SetLetter(char letter)
        {
            this.letter = letter;
        }
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }
    }
}
