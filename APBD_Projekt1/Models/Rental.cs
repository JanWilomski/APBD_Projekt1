namespace APBD_Projekt1.Models;

public class Rental
{
    public User User { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime MaxReturnDate { get; set; }
    public Equipment.Equipment Equipment { get; set; }
    public bool? ReturnedInTime { get; private set; }
    public int IdRental { get; }
    private static int _nextId = 1;

    public Rental(User user, Equipment.Equipment equipment, DateTime rentalDate, DateTime maxReturnDate)
    {
        RentalDate = rentalDate;
        MaxReturnDate = maxReturnDate;
        Equipment = equipment;
        IdRental = _nextId++;
        User = user;
        
        
    }
    
    
    public void Return(DateTime returnDate){
        ReturnDate = returnDate;
        if (ReturnDate > MaxReturnDate)
        {
            ReturnedInTime = false;
        }else ReturnedInTime = true;
    }
    
}