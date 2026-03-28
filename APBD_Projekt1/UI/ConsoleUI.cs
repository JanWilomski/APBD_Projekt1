using APBD_Projekt1.Models;
using APBD_Projekt1.Models.Equipment;
using APBD_Projekt1.Services;
using APBD_Projekt1.Enums;

namespace APBD_Projekt1.UI;

public class ConsoleUI
{
    private readonly RentalService _rentalService;
    private readonly EquipmentService _equipmentService;
    private readonly UserService _userService;

    public ConsoleUI(RentalService rentalService, EquipmentService equipmentService, UserService userService)
    {
        _rentalService = rentalService;
        _equipmentService = equipmentService;
        _userService = userService;
    }

    public void PrintAllEquipment()
    {
        Console.WriteLine("All Equipment:");
        foreach (var e in _equipmentService.GetAllEquipment())
            Console.WriteLine($"ID: {e.IdEquipment} {e.Name} - {e.AvailabilityStatus}");
    }

    public void PrintAvailableEquipment()
    {
        Console.WriteLine("Available Equipment:");
        foreach (var e in _equipmentService.GetAvailableEquipment())
            Console.WriteLine($"ID: {e.IdEquipment} {e.Name}");
    }

    public void PrintActiveRentals(User user)
    {
        Console.WriteLine($"Active Rentals for {user.Name} {user.Surname}:");
        foreach (var r in _rentalService.GetActiveRentals(user))
            Console.WriteLine($"ID: {r.IdRental} {r.Equipment.Name}: {r.MaxReturnDate:dd-MM-yyyy}");
    }

    public void PrintOverdueRentals()
    {
        Console.WriteLine("Overdue Rentals:");
        foreach (var r in _rentalService.GetOverdueRentals())
            Console.WriteLine($"ID: {r.IdRental} {r.User.Name} {r.User.Surname} - {r.Equipment.Name}: {r.MaxReturnDate:dd-MM-yyyy}");
    }
    public void PrintAllUsers()
    {
        Console.WriteLine("All Users:");
        foreach (var user in _userService.GetAllUsers())
            Console.WriteLine($"ID: {user.Id} {user.Name} {user.Surname} - {user.Type}");
    }

    public void PrintReport()
    {
        var all = _equipmentService.GetAllEquipment();
        var available = _equipmentService.GetAvailableEquipment();
        var overdue = _rentalService.GetOverdueRentals();

        Console.WriteLine("Report:");
        Console.WriteLine($"Total equipment: {all.Count}");
        Console.WriteLine($"Available: {available.Count}");
        Console.WriteLine($"Rented out: {all.Count - available.Count}");
        Console.WriteLine($"Overdue rentals: {overdue.Count}");
    }
}
