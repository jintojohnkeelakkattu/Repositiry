using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
        public string Company { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public int UserId { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
