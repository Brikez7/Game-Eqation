using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WPF.Classes
{
    class CustomRecordComparer : IComparer<Record>
    {
        public int Compare(Record? x, Record? y)
        {
            int xLength = x?.Round ?? 0;
            int yLength = y?.Round ?? 0;
            return xLength - yLength;
        }
    }

    internal class TRecordes
    { 
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

        public static bool Search(string name, out Record? userRecord)
        {
            using (Database db = new Database())
            {
                var record = db.Recordes.ToList();
                userRecord = record.Find(x => x.NameUser == name);
                return userRecord != null;
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

        public static List<Record> Sort()
        {
            using (Database db = new Database())
            {
                var users = db.Recordes.ToList();

                return users.OrderBy(x => x,new CustomRecordComparer()).ToList();
            }
        }
    }
}
