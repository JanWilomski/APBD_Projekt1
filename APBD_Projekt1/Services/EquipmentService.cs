using APBD_Projekt1.Enums;
using APBD_Projekt1.Models.Equipment;

namespace APBD_Projekt1.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipment = new();

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        List<Equipment> availableEquipment = new();
        foreach (var equipment in _equipment){
            if (equipment.AvailabilityStatus == Enums.EquipmentAvailabilityStatus.Available){
                availableEquipment.Add(equipment);
            }
        }

        return availableEquipment;
    }

    public static void MarkUnavailable(Equipment equipment)
        => equipment.AvailabilityStatus = EquipmentAvailabilityStatus.Unavailable;
}
