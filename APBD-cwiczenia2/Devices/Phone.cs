namespace APBD_cwiczenia2.Devices
{
    public class Phone(int batteryCapacity, OS os) : Device
    {
        public int BatteryCapacity { get; set; } = batteryCapacity;
        public OS OS { get; set; } = os;
    }

    public enum OS
    {
        Android,
        iOS,
        WindowsPhone
    }
}
