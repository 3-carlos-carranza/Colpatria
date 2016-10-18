namespace Core.Entities.User
{
    public class UserRole
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
