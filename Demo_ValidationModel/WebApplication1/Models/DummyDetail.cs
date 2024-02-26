﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DummyDetail
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; } = null!;
        public int MasterId { get; set; }

        public virtual DummyMaster Master { get; set; } = null!;
    }
}
