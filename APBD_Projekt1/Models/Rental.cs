namespace APBD_Projekt1.Services;

public class Rental
{
    public User User { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime MaxReturnDate { get; set; }
    public Equipment Equipment { get; set; }
    public bool? ReturnedInTime { get; private set; }

    public Rental(DateTime rentalDate, DateTime maxReturnDate, Equipment equipment)
    {
        RentalDate = rentalDate;
        MaxReturnDate = maxReturnDate;
        Equipment = equipment;
        
        
        
    }
    
    
    public void Return(DateTime returnDate){
        ReturnDate = returnDate;
        if (ReturnDate > MaxReturnDate)
        {
            ReturnedInTime = false;
        }
    }
    
}