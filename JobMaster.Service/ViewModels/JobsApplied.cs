using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster.Service.ViewModels
{
    public class JobsApplied : BaseEntity
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
