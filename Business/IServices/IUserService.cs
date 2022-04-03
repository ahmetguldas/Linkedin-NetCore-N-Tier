using Data.Entities;

namespace Business.IServices
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUserById(int id);
        List<User> GetAllUser();
        void UpdateUserImage(string ImageUrl, int id);
    }
}
