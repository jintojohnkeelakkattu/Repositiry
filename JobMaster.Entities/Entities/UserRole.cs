

namespace JobMaster
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual T User { get; set; }
        public virtual Role Role { get; set; }

    }
}
