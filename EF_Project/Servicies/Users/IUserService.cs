using EF_Project.ViewModels.UserModels;

namespace EF_Project.Servicies.Users
{
    public interface IUserService
    {
        void Create(UserRequestModel model);
        void Update(int id, UserRequestModel model);
        void Delete(int id);
        UserResponseModel GetById(int id);
        IEnumerable<UserResponseModel> GetAll();
        bool LogIn(LogInModel model);
    }
}
