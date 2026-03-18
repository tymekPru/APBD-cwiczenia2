using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;

namespace APBD_cwiczenia2
{
    public class Rental(int id, Device device, User user, DateTime deadline)
    {
        public int Id { get; } = id;
        public User User { get; } = user;
        public Device Device { get; } = device;
        public DateTime RentDate { get; } = DateTime.Now;
        public DateTime Deadline { get; } = deadline;
        public DateTime? ReturnDate { get; set; } = null;
        public decimal AdditionalCost { get; set; } = 0;
        public bool IsActive => ReturnDate == null;
        public decimal ReturnDevice(DateTime? returnDate = null)
        {
            if (!IsActive)
                return Device.RentalPrice + AdditionalCost;

            ReturnDate = returnDate ?? DateTime.Now;
            Device.SetAvailable();

            if (ReturnDate.Value > Deadline)
            {
                var lateDays = (ReturnDate.Value.Date - Deadline.Date).Days;
                AdditionalCost = lateDays * (Device.RentalPrice * 0.10m);
            }

            var totalPrice = Device.RentalPrice + AdditionalCost;
            return totalPrice;
        }
        public override string ToString()
        {
            return $"[{Id}] {User.FirstName} {User.LastName} - {Device.Name} status: {(IsActive ? "Not returned" : "Returned")}, deadline: {Deadline}";
        }
    }
}
