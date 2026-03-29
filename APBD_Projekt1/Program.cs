using APBD_Projekt1.Enums;
using APBD_Projekt1.Models;
using APBD_Projekt1.Models.Equipment;
using APBD_Projekt1.Services;
using APBD_Projekt1.UI;

var equipmentService = new EquipmentService();
var userService = new UserService();
var rentalService = new RentalService();
var ui = new ConsoleUI(rentalService, equipmentService, userService);

userService.AddUser(new User("Kacper", "Kowalski", UserType.Student));
userService.AddUser(new User("Anna", "Nowak", UserType.Student));
userService.AddUser(new User("Jan", "Wilomski", UserType.Employee));

ui.PrintAllUsers();

equipmentService.AddEquipment(new Laptop("Dell", 512, 32));
equipmentService.AddEquipment(new Camera("Canon", 24, true));
equipmentService.AddEquipment(new Projector("Epson", 1920, 1080));

var projector2 = new Projector("BenQ", 1280, 720);
equipmentService.AddEquipment(projector2);
projector2.AvailabilityStatus = EquipmentAvailabilityStatus.Unavailable;

ui.PrintAllEquipment();
ui.PrintAvailableEquipment();

var kacper = userService.GetUserById(1)!;
var anna = userService.GetUserById(2)!;
var laptop = equipmentService.GetAllEquipment()[0];
var camera = equipmentService.GetAllEquipment()[1];
var projector = equipmentService.GetAllEquipment()[2];

var rental1 = rentalService.RentEquipment(kacper, laptop, 7);
var rental2 = rentalService.RentEquipment(kacper, camera, 5);

ui.PrintActiveRentals(kacper);

try
{
    rentalService.RentEquipment(kacper, projector, 3);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

try
{
    rentalService.RentEquipment(anna, projector2, 3);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

var penalty1 = rentalService.ReturnEquipment(rental1, DateTime.Now);
Console.WriteLine($"Returned: {laptop.Name}. Penalty: {penalty1} zł");

var overdueRental = rentalService.RentEquipment(anna, projector, 7, DateTime.Now.AddDays(-14));

ui.PrintOverdueRentals();

var penalty2 = rentalService.ReturnEquipment(overdueRental, DateTime.Now);
Console.WriteLine($"Returned too late: {projector.Name}. Penalty: {penalty2} zł");

ui.PrintAllEquipment();
ui.PrintReport();
