using System;
using System.Collections.Generic;
using System.Text;

namespace JobMaster
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}
