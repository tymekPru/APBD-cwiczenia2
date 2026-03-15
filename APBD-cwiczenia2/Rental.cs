using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;

namespace APBD_cwiczenia2
{
    public class Rental
    {
        public int Id { get; set; }
        public Student User { get; set; }
        public Device Device { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal AdditionalCost { get; set; }
    }
}
