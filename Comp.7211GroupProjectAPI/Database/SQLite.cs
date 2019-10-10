using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Comp._7211GroupProjectAPI.Database
{
    public class SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var db = "AppDatabase";
            var path = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), db);

            return new SQLiteConnection(path);
        }
    }
}