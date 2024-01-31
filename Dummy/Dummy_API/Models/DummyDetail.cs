using System;
using System.Collections.Generic;

namespace Dummy_API.Models
{
    public partial class DummyDetail
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; } = null!;
        public int MasterId { get; set; }

        public virtual DummyMaster Master { get; set; } = null!;
    }
}
