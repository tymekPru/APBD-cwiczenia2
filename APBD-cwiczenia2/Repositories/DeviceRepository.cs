using APBD_cwiczenia2.Devices;

namespace APBD_cwiczenia2.Repositories
{
    public class DeviceRepository
    {
        private readonly List<Device> _devices = [];
        private int _nextId = 1;
        public Camera AddCamera(string name, decimal rentalPrice, string description, int mpx, bool hasVideoRecording)
        {
            var camera = new Camera(_nextId++, name, rentalPrice, description, mpx, hasVideoRecording);
            _devices.Add(camera);
            return camera;
        }
        public Laptop AddLaptop(string name, decimal rentalPrice, string description, int ramGb, ScreenResolution sr)
        {
            var laptop = new Laptop(_nextId++, name, rentalPrice, description, ramGb, sr);
            _devices.Add(laptop);
            return laptop;
        }
        public Phone AddPhone(string name, decimal rentalPrice, string description, int batteryCapacity, OS os)
        {
            var phone = new Phone(_nextId++, name, rentalPrice, description, batteryCapacity, os);
            _devices.Add(phone);
            return phone;
        }
        public void ListAllDevices()
        {
            _devices
                .ForEach(Console.WriteLine);
        }
        public void ListAvailableDevices()
        {
            _devices
                .Where(x => x.Availability == Availability.Available)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}