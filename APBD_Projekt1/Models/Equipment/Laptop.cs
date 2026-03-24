namespace APBD_Projekt1.Models.Equipment;

public class Laptop : Equipment
{

    public int StorageGB { get; set; }
    public int RamGB { get; set; }
    public Laptop(string name, int storageGB, int ramGB) : base(name)
    {
        StorageGB = storageGB;
        RamGB = ramGB;
    }
}