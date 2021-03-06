using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheese_factory.Core
{
    public static class DBContextCommands
    {
        // delet method (:
        public  static void AddItemsIntoCollection<T>(ObservableCollection<T> collection, DbSet<T> dbSet)
            where T : class
        {
            foreach (var item in dbSet)
            {
                collection.Add(item);
            }
        }

        public static void DeleteItem<T>(MyDBContext db, DbSet<T> table, T item)
        where T : class
        {
            if (db == null ||
                table == null || item == null)
                return;

            table.Remove(item);
            db.SaveChanges();
        }

        public static void UpdateItems<T>(ObservableCollection<T> collection, DbSet<T> table)
        where T : class
        {
            if (table == null) 
                return;

            if (collection != null) 
                collection.Clear();
            else 
                collection = new ObservableCollection<T>();

            foreach (var item in table)
            {
                collection.Add(item);
            }
        }

        public static void AddItem<T>(MyDBContext db, DbSet<T> table, T item)
        where T : class
        {
            if (db == null ||
               table == null || item == null)
                return;

            table.Add(item);
            db.SaveChanges();
        }

        public static void ChangeExistingItem<T>(MyDBContext db, T oldItem, T newItem)
        where T : class
        {
            db
                    .Entry(oldItem)
                    .CurrentValues
                    .SetValues(newItem);
            db.SaveChanges();
        }
    }
}
