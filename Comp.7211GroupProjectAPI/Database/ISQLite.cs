using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}