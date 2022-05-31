using System.Linq;


namespace WPF.Classes
{
    internal class Recordes
    {
        public static void Add(string name, int time)
        {
            using (Database db = new Database())
            {
                Record newRecord = new Record { NameUser = name, Level = time };
                // Добавление
                db.Recordes.Add(newRecord);
                db.SaveChanges();
            }
        }
        public static bool Search(string name)
        {
            using (Database db = new Database())
            {
                var record = db.Recordes.ToList();

                return record.Any(x => x.NameUser == name);
            }
        }
        public static void Delete(string name)
        {
            using (Database db = new Database())
            {
                Record? record = db.Recordes.FirstOrDefault(x => x.NameUser == name);
                if (record != null)
                {
                    db.Recordes.Remove(record);
                    db.SaveChanges();
                }

            }
        }
        public static void Change(string name, int level)
        {
            using (Database db = new Database())
            {
                Record? record = db.Recordes.FirstOrDefault(x => x.NameUser == name);
                if (record != null)
                {
                    record.Level = level;
                    db.SaveChanges();
                }
            }
        }
    }
}
