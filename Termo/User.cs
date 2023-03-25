using System;
namespace Termo
{
    internal class User
    {
        //Atribute
        private string nickname;
        private int wins;
        private int loses;
        public User(string nickname) 
        { 
            this.nickname = nickname;
            this.wins = 0;
            this.loses = 0;
        }
        public string GetNickname()
        {
            return nickname;
        }
        public int GetWins()
        {
            return wins;
        }
        public int GetLoses()
        {
            return loses;
        }
        public void PlusWins()
        {
            this.wins++;
        }
        public void PlusLoses()
        {
            this.loses++;
        }
    }
}
