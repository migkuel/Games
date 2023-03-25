using System;

namespace Games
{
    internal class HangmanWord
    {
        //Atribute
        private string word;
        private string tip;
        //Constructor
        public HangmanWord(string word, string tip)
        {
            this.word = word;
            this.tip = tip;
        }
        public HangmanWord()
        {
        }
        //Getters and Setters
        public string GetWord()
        {
            return word;
        }
        public string GetTip()
        {
            return tip;
        }
        public void SetWord(string word)
        {
            this.word = word;
        }
        public void SetTip(string tip)
        {
            this.tip = tip;
        }
    }
}
