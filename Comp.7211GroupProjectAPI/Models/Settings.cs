﻿using System;
using System.Collections.Generic;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Settings
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string AppTheme { get; set; }

        // Below was generated by scaffolding to represent our Foreign Keys
        // DO NOT REMOVE. THE DB CONTEXT USES THEM

        public virtual Users U { get; set; }
    }
}
