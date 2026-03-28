using APBD_Projekt1.Models;
using APBD_Projekt1.Models.Equipment;

namespace APBD_Projekt1.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new();
    private const int PenaltyPerDay = 10;

    public Rental RentEquipment(User user, Equipment equipment, int days)
        => RentEquipment(user, equipment, days, DateTime.Now);

    public Rental RentEquipment(User user, Equipment equipment, int days, DateTime startDate)
    {
        if (equipment.AvailabilityStatus != Enums.EquipmentAvailabilityStatus.Available)
            throw new InvalidOperationException("Equipment is not available for rent.");

        if (GetActiveRentals(user).Count >= user.RentalLimit)
            throw new InvalidOperationException("User has reached the rental limit.");

        var rental = new Rental(user, equipment, startDate, startDate.AddDays(days));
        _rentals.Add(rental);
        equipment.AvailabilityStatus = Enums.EquipmentAvailabilityStatus.Unavailable;
        return rental;
    }

    public double ReturnEquipment(Rental rental, DateTime returnDate)
    {
        rental.Return(returnDate);
        rental.Equipment.AvailabilityStatus = Enums.EquipmentAvailabilityStatus.Available;
        if (rental.ReturnedInTime == false)
        {
            int daysLate = (returnDate - rental.MaxReturnDate).Days;
            return daysLate * PenaltyPerDay;
        }else return 0;
    }

    public List<Rental> GetActiveRentals(User user)
    {
        var activeRentals = new List<Rental>();
        foreach (var rental in _rentals)
        {
            if (rental.User.Id == user.Id && rental.ReturnDate == null)
            {
                activeRentals.Add(rental);
            }
        }
        return activeRentals;
    }

    public List<Rental> GetOverdueRentals()
    {
        var overdueRentals = new List<Rental>();
        foreach (var rental in _rentals)
        {
            if (rental.ReturnDate == null && rental.MaxReturnDate < DateTime.Now)
            {
                overdueRentals.Add(rental);
            }
        }
        return overdueRentals;
    }
    

    public string PrintReport()
    {
        var report = "Rental Report:\n";
        foreach (var rental in _rentals)
        {
            string status = rental.ReturnDate == null ? "Active" : "Returned";
            report += $"Rental ID: {rental.IdRental}, User: {rental.User.Name} {rental.User.Surname}, Equipment: {rental.Equipment.Name}, Rental Date: {rental.RentalDate}, Max Return Date: {rental.MaxReturnDate}, Status: {status}\n";
        }
        return report;
    }
}

