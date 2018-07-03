

namespace JobMaster { 
   public class UserPhone: BaseEntity
    {
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
