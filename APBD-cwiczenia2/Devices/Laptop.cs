namespace APBD_cwiczenia2.Devices
{
    public class Laptop(int id, string name, decimal rentalPrice, string description, int ramGb, ScreenResolution screenResolution) : Device(id, name, rentalPrice, description)
    {
        public int RamGb { get; } = ramGb;
        public ScreenResolution ScreenResolution { get; } = screenResolution;
        public override string ToString()
        {
            return $"{BasePrint()} {RamGb}GB RAM, Screen resolution: {ScreenResolution}";
        }
    }
    public enum ScreenResolution
    {
        HD,
        FullHD,
        QHD,
        UHD
    }
}
