
namespace JobMaster
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual UserRole UserRole {get; set;}
    }
}
