using APBD_Projekt1.Enums;

namespace APBD_Projekt1;

public class User
{
    private static int _nextId = 1;
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserType Type { get; set; }
    public int Id { get; }
    public int RentalLimit { get; }

    public User(string name, string surname, UserType type)
    {
        Id = _nextId++;
        Name = name;
        Surname = surname;
        Type = type;
        if(type == UserType.Student)
            RentalLimit = 2;
        else if(type == UserType.Employee)
            RentalLimit = 5;
    }
    
    
    
}