

namespace JobMaster { 
   public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
