namespace EF_Project.Entities
{
    public class Password : BaseEntity
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
