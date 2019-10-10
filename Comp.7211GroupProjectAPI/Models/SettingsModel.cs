using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Models
{
    public class SettingsModel
    {
        [PrimaryKey, AutoIncrement]
        public string AppTheme { get; set; }
    }
}