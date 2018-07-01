

using System;
using System.Collections.Generic;

namespace JobMaster {
    public class T : BaseEntity
    {
        public T()
        {
            UserRoles = new List<UserRole>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedUtc { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserPhone> UserPhones {get;set;}
    }
}
