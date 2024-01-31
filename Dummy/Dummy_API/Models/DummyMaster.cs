using System;
using System.Collections.Generic;

namespace Dummy_API.Models
{
    public partial class DummyMaster
    {
        public DummyMaster()
        {
            DummyDetails = new HashSet<DummyDetail>();
        }

        public int MasterId { get; set; }
        public string MasterName { get; set; } = null!;

        public virtual ICollection<DummyDetail> DummyDetails { get; set; }
    }
}
