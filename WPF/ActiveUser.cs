using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Classes;

namespace WPF
{
    internal class ActiveUser
    {
        private string Name { get; set; }

        private static ActiveUser? _activeUser;

        public static void SetNewUser(string name) => _activeUser = new ActiveUser(name);

        public static string? GetName() => _activeUser?.Name;

        public static void Disactive() => _activeUser = null;

        public static bool CheckActive() => _activeUser != null;

        public static void AddRecord(int round) 
        {
            TRecordes.Add(GetName(), round);
        }

        public static bool UpdateRecord(int round) 
        {
            if (TRecordes.Find($"{_activeUser.Name}").Round > round) 
            {
                return false;
            }
            else 
            {
                TRecordes.Change(GetName(), round);
                return true;
            }

        }

        private ActiveUser(string name)
        {
            Name = name;
        }
    }
}
