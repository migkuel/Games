using System.IO;

namespace Termo
{
    internal class UserManager
    {
        private User user;

        public UserManager() { }
        public User GetCurrentUser()
        {
            return user;
        }
        public void SaveUser(User user) 
        {
            File.AppendAllText("Score.txt", ConvertUserToString(user));
        }
        public string ConvertUserToString(User user)
        {
            return user.GetNickname() + "," + user.GetWins().ToString() + "," + user.GetLoses().ToString();
        }
    }
}
