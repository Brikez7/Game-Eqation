using System.Collections.Generic;
using System.Linq;

namespace WPF.Classes
{
    internal class TRecordes
    {
        static TRecordes() 
        {
            Database.UpdateDB();
        }

        public static void Add(string name, int time)
        {
            using (Database db = new Database())
            {
                Record newRecord = new Record { NameUser = name, Round = time };

                db.Recordes.Add(newRecord);
                db.SaveChanges();
            }
        }
        public static List<Record> GetTable() 
        {
            using (Database db = new Database())
            {
                List<Record> tableRecordes =  db.Recordes.ToList();
                return tableRecordes;
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
                    record.Round = level;
                    db.SaveChanges();
                }
            }
        }
    }
}
