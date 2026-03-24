namespace APBD_Projekt1.Models.Equipment;

public class Camera : Equipment
{

    public double ResolutionMegapixels { get; set; }
    public bool HasStabilization { get; set; }
    public Camera(string name, double resolutionMegapixels, bool hasStabilization) : base(name)
    {
        ResolutionMegapixels = resolutionMegapixels;
        HasStabilization = hasStabilization;
    }


}