using System.ComponentModel.DataAnnotations;

namespace EF_Project.ViewModels.UserModels
{
    public class UserRequestModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
