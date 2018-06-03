

using System;
using System.Collections.Generic;

namespace JobMaster {
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedUtc { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserPhone> UserPhones {get;set;}
    }
}
