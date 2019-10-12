using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Comp._7211GroupProjectAPI.Database
{
    public class SQLiteC : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var db = "ProjectDatabase";
            var path = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.ApplicationData), db);

            return new SQLiteConnection(path);
        }
    }
}