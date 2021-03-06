using System.Linq;
using WPF.Database;

namespace WPF.Classes
{
    internal static class TUsers
    {
        public static void Add(string name, string password) 
        {
            using (Database.Database db = new())
            {
                User newUser = new() { NameUser = name, Password = password };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public static bool CheckPassword(string name, string password)
        {
            using (Database.Database db = new())
            {
                var users = db.Users.ToList();

                return users.Any(x => x.NameUser == name && x.Password == password);
            }
        }

        public static bool SearchUser(string name)
        {
            using (Database.Database db = new())
            {
                var users = db.Users.ToList();

                return users.Any(x => x.NameUser == name);
            }
        }

        public static void Delete(string name)
        {
            using (Database.Database db = new())
            {
                User? user = db.Users.FirstOrDefault(x => x.NameUser == name);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public static void Change(string name, string newPassword)
        {
            using (Database.Database db = new())
            {
                User? user = db.Users.FirstOrDefault(x => x.NameUser == name);
                if (user != null)
                {
                    user.Password = newPassword;
                    db.SaveChanges();
                }
            }
        }
    }
}
