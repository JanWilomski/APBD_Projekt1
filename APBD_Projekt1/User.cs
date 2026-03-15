namespace APBD_Projekt1;

public class User
{
    public enum UserType
    {
        STUDENT,
        Teacher,
    }
    
    public string name { get; set; }
    public string surname { get; set; }
    public UserType type { get; set; }
    public int id { get; set; }
    
    
    
}