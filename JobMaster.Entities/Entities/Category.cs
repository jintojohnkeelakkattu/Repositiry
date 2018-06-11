using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public virtual Category MasterCategory { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
