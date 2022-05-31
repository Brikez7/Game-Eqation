using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Classes
{
    internal static class Users
    {
        public static void Add(string name, string password) 
        {
            using (Database db = new Database())
            {
                User newUser = new User { NameUser = "Tom", Password = password };
                // Добавление
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        public static bool Search(string name, string password)
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
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Password = newPassword;
                    db.SaveChanges();
                }
            }
        }
    }
}
