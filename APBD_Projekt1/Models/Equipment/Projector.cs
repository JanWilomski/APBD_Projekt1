namespace APBD_Projekt1.Models.Equipment;

public class Projector : Equipment
{

    public int ResolutionWidth { get; set; }
    public int ResolutionHeight { get; set; }
    public Projector(string name, int resolutionWidth, int resolutionHeight) : base(name)
    {
        ResolutionWidth = resolutionWidth;
        ResolutionHeight = resolutionHeight;
    }
}