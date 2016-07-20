using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLiteNetExtensions;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;

namespace ClassLibraryEntity
{
    public class SQLiteManager<T> : SQLiteConnection where T : EntityBase
    {
        public SQLiteManager() : base(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), ApplicationData.Current.LocalFolder.Path + "\\SQLitePokemonDB")
        {
            
            try
            {
                this.CreateTable<T>();
            }
            catch (Exception)
            {
                this.MigrateTable<T>();
            }
        }

        public void Insert(T item)
        {
            int id = Int32.Parse(item.ToString());

            if (id == 0)
            {
                base.Insert(item);
            }
            else
            {
                base.InsertOrReplace(item);
            }
        }

        public void InserAll(List<T> items)
        {
            this.InsertAllWithChildren(items);
        }
        
        public T Get(T item)
        {
            return this.Get<T>(item.ToString());
        }

        public T Get(int id)
        {
            return this.Get<T>(id);
        }

        public List<T> Get(List<T> items)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                result.Add(this.Get(item));
            }

            return result;
        }

        public List<T> Get(List<int> items)
        {
            List<T> result = new List<T>();
            foreach (var item in items)
            {
                result.Add(this.Get(item));
            }

            return result;
        }
    }
}
