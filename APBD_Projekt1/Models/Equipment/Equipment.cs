using APBD_Projekt1.Enums;

namespace APBD_Projekt1;

public abstract class Equipment
{
    private static int _nextId = 1;
    public int IdEquipment { get; set; }
    public String Name { get; set; }
    public EquipmentAvailabilityStatus AvailabilityStatus { get; set; }


    public Equipment(String name)
    {
        Name = name;
        IdEquipment = _nextId++;
    }
    
}