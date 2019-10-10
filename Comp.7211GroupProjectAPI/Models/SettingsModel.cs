using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Models
{
    public class SettingsModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int UId { get; set; }
        public string AppTheme { get; set; }
    }
}