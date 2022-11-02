using EF_Project.Entities;
using EF_Project.Helpers.Repositories;
using EF_Project.ViewModels.UserModels;

namespace EF_Project.Servicies.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repositoryUser;
        private readonly IRepository<Password> _repositoryPassword;

        public UserService(IRepository<User> repositoryUser,
            IRepository<Password> repositoryPassword)
        {
            _repositoryUser = repositoryUser;
            _repositoryPassword = repositoryPassword;
        }

        public void Create(UserRequestModel model)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);


            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                IsActive = true,
                CreatedBy = "Armen Samsonyan",
                UpdatedBy = "Armen Samsonyan",
            };

            Password password = new Password
            {
                User = user,
                PasswordHash = passwordHash,
                IsActive = true,
                CreatedBy = "Armen Samsonyan",
                UpdatedBy = "Armen Samsonyan"
            };

            _repositoryUser.Insert(user);
            _repositoryPassword.Insert(password);
            _repositoryUser.Save();
        }

        public void Update(int id, UserRequestModel model)
        {
            var user = _repositoryUser.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            _repositoryUser.Update(user);
            _repositoryUser.Save();
        }

        public void Delete(int id)
        {
            var user = _repositoryUser.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _repositoryUser.Remove(user);
            _repositoryUser.Save();
        }

        public UserResponseModel GetById(int id)
        {
            var user = _repositoryUser.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            UserResponseModel response = new UserResponseModel()
            {
                UserId = user.Id,
                Name = user.FirstName,
                Surname = user.LastName,
                Email = user.Email
            };

            return response;
        }

        public IEnumerable<UserResponseModel> GetAll()
        {
            var users = _repositoryUser.GetAll();

            var response = users.Where(q => q.FirstName == "Armen")
                .Select(u => new UserResponseModel
                {
                    UserId = u.Id,
                    Name = u.FirstName,
                    Surname = u.LastName,
                    Email = u.Email
                }).ToList();

            return response;
        }

        public bool LogIn(LogInModel model)
        {
            var users = _repositoryUser.GetAll();

            var user = users.FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var passwords = _repositoryPassword.GetAll();

            var password = passwords.FirstOrDefault(p => p.UserId == user.Id);

            bool verified = BCrypt.Net.BCrypt.Verify(model.Password, password.PasswordHash);

            if (!verified)
            {
                throw new Exception("Email or Password incorrect");
            }
            return true;
        }
    }
}
