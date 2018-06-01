
namespace JobMaster
{
    public class Role : BaseEntity
    {
        public int Name { get; set; }
        public virtual UserRole UserRole {get; set;}
    }
}
