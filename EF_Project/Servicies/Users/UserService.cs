using EF_Project.Entities;
using EF_Project.Helpers;
using EF_Project.Helpers.Repositories;
using EF_Project.ViewModels;
using EF_Project.ViewModels.UserModels;

namespace EF_Project.Servicies.Users
{
    public class UserService : IUserService
    {
        //private readonly DataContext _context;

        //public UserService(DataContext context)
        //{
        //    _context = context;
        //}

        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Create(UserRequestModel model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsActive = true,
                CreatedBy = "Armen Samsonyan",
                UpdatedBy = "Armen Samsonyan"
            };

            _repository.Insert(user);
            _repository.Save();
        }

        public void Update(int id, UserRequestModel model)
        {
            var user = _repository.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            _repository.Update(user);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _repository.Remove(user);
            _repository.Save();
        }

        public UserResponseModel GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            UserResponseModel response = new UserResponseModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return response;
        }

        public IEnumerable<UserResponseModel> GetAll()
        {
            var users = _repository.GetAll();

            var response = users.Select(u => new UserResponseModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();

            return response;
        }
    }
}
