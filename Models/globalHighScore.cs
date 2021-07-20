using System.Collections.Generic;
using System.Linq;

namespace Lottery_system.Models
{
    public static class globalHighScore
    {
        public static int highestScore = 0;
        public static string highestUser = "";
        public static string highestMagic = "";
        private static bool isSorted = true;
        private static List<users> users = new List<users>();

        public static void addScore(users user)
        {
            if (user.score > highestScore)
            {
                highestScore = user.score;
                highestUser = user.userName;
                highestMagic = user.magic;
            }
            users.Add(user);
            isSorted = false;
        }

        public static void removeScore(users user)
        {
            if (users.Count() > 0)
            {
                users.RemoveAll(listUser => listUser.userName == user.userName); // removing the score
                if (user.userName == highestUser)
                {
                    if (users.Count() > 0)
                    {
                        if (!isSorted)
                        {
                            users.OrderBy(userObj => userObj.score); //sorting the list
                            isSorted = true;
                        }
                        highestUser = users[0].userName;
                        highestScore = users[0].score;
                        highestMagic = users[0].magic;
                    } else
                    {
                        highestUser = "";
                        highestScore = 0;
                        highestMagic = "";
                    }
                }
            }
        }
    }
}
