namespace EF_Project.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public int CityId { get; set; }

        //public City City { get; set; }
        public Password Password { get; set; }
    }
}
