using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;
namespace APBD_cwiczenia2
{
    public class AppState
    {
        public List<Device> Devices { get; set; } = [];
        public int NextDeviceId { get; set; }
        public List<User> Users { get; set; } = [];
        public int NextUserId { get; set; }
        public List<Rental> Rentals { get; set; } = [];
        public int NextRentalId { get; set; }
    }
}