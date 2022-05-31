﻿using System.Linq;


namespace WPF.Classes
{
    internal static class Users
    {
        public static void Add(string name, string password) 
        {
            using (Database db = new Database())
            {
                User newUser = new User { NameUser = name, Password = password };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        public static bool SearchUser(string name, string password)
        {
            using (Database db = new Database())
            {
                var users = db.Users.ToList();

                return users.Any(x => x.NameUser == name && x.Password == password);
            }
        }
        public static void Delete(string name)
        {
            using (Database db = new Database())
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
            using (Database db = new Database())
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
