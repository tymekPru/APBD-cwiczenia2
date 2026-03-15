namespace APBD_cwiczenia2.Devices
{
    public class Laptop(int ramGb, ScreenResolution screenResolution) : Device
    {
        public int RamGb { get; set; } = ramGb;
        public ScreenResolution ScreenResolution { get; set; } = screenResolution;
    }
    public enum ScreenResolution
    {
        HD,
        FullHD,
        QHD,
        UHD
    }
}
