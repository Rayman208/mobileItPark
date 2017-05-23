using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;

using System.IO;

namespace ActivityDiary
{
    class DataBase
    {
        private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        private string DBName = "activities.db";

        public bool CreateTable()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Path.Combine(folder,DBName)))
                {
                    con.CreateTable<Act>();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool InsertNew(Act act)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Path.Combine(folder, DBName)))
                {
                    con.Insert(act);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<Act> SelectAll()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Path.Combine(folder, DBName)))
                {
                    return con.Table<Act>().ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public Act SelectByIndex(int index)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Path.Combine(folder, DBName)))
                {
                    return con.Table<Act>().ToList()[index];
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(Act act)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Path.Combine(folder, DBName)))
                {
                    con.Delete(act);
                    return true;
                }
            }
            catch 
            {
                return false;   
            }
        }
    }
}