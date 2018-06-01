using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster
{
    public class JobDetail : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int ParentId { get; set; }

    }
}
