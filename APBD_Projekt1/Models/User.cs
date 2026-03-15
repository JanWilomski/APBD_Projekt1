using APBD_Projekt1.Enums;

namespace APBD_Projekt1;

public class User
{
    public static int _nextId = 1;
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserType Type { get; set; }
    public int Id { get; set; }

    public User(string name, string surname, UserType type)
    {
        Id = _nextId++;
        Name = name;
        Surname = surname;
        Type = type;
    }
    
    
    
}