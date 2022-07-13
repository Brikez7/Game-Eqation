using WPF.Classes;

namespace WPF
{
    internal class ActiveUser
    {
        private string Name { get; set; }

        private static ActiveUser? _activeUser;

        public static void SetNewUser(string name) 
            => _activeUser = new ActiveUser(name);

        public static string? GetName() 
            => _activeUser?.Name;

        public static void Disactive() 
            => _activeUser = null;

        public static bool CheckActive()
            => _activeUser != null;

        public static void AddRecord(int round)
        {
            string? nameActiveUser = GetName();
            TRecordes.Add(nameActiveUser, round);
        }

        public static bool UpdateRecord(int round) 
        {
            if (TRecordes.Find($"{_activeUser?.Name}")?.Round > round) 
            {
                return false;
            }
            else 
            {
                string? nameActiveUser = GetName();
                TRecordes.Change(nameActiveUser, round);
                return true;
            }

        }

        private ActiveUser(string name)
        {
            Name = name;
        }
    }
}
