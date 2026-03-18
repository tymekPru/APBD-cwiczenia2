namespace APBD_cwiczenia2.Devices
{
    public class Phone(int id, string name, decimal rentalPrice, string description, int batteryCapacity, OS os) : Device(id, name, rentalPrice, description)
    {
        public int BatteryCapacity { get; } = batteryCapacity;
        public OS OS { get; } = os;
        public override string ToString()
        {
            return $"{BasePrint()} {BatteryCapacity}mAh, OS: {os}";
        }
    }

    public enum OS
    {
        Android,
        iOS,
        WindowsPhone
    }
}
