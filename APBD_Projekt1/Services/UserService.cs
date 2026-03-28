using APBD_Projekt1.Models;

namespace APBD_Projekt1.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }
}
