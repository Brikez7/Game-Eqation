using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WPF.Database;

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
            using (Database.Database db = new Database.Database())
            {
                Record newRecord = new Record { NameUser = name, Round = time };

                db.Recordes.Add(newRecord);
                db.SaveChanges();
            }
        }

        public static List<Record> GetTable() 
        {
            using (Database.Database db = new Database.Database())
            {
                var tableRecordes =  db.Recordes.AsNoTracking().ToList();
                return tableRecordes;
            }
        }

        public static bool Search(string name)
        {
            using (Database.Database db = new Database.Database())
            {
                var record = db.Recordes.ToList();

                return record.Any(x => x.NameUser == name);
            }
        }

        public static bool Search(string name, out Record? userRecord)
        {
            using (Database.Database db = new Database.Database())
            {
                var record = db.Recordes.ToList();
                userRecord = record.Find(x => x.NameUser == name);
                return userRecord != null;
            }
        }

        public static Record? Find(string name)
        {
            using (Database.Database db = new Database.Database())
            {
                var record = db.Recordes.ToList();
                var userRecord = record.Find(x => x.NameUser == name);
                return userRecord;
            }
        }

        public static void Delete(string name)
        {
            using (Database.Database db = new Database.Database())
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
            using (Database.Database db = new Database.Database())
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
            using (Database.Database db = new Database.Database())
            {
                var users = db.Recordes.ToList();

                return users.OrderBy(x => x,new CustomRecordComparer()).ToList();
            }
        }
    }
}
