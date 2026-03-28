using APBD_Projekt1.Enums;

namespace APBD_Projekt1.Models.Equipment;

public abstract class Equipment
{
    private static int _nextId = 1;
    public int IdEquipment { get; }
    public string Name { get; set; }
    public EquipmentAvailabilityStatus AvailabilityStatus { get; set; } = EquipmentAvailabilityStatus.Available;


    public Equipment(string name)
    {
        Name = name;
        IdEquipment = _nextId++;
    }

    public override string ToString()
    {
        return $"ID: {IdEquipment} {Name} ({GetType().Name}) - {AvailabilityStatus}";
    }
}