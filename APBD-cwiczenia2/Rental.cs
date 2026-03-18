using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;
using Microsoft.VisualBasic;

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
        public decimal ReturnDevice()
        {
            ReturnDate = DateTime.Now;
            Device.SetAvailable();
            //Business rule: if more than 14 days late then pay double
            var difference = ReturnDate - RentDate;
            if (difference?.Days > 14)
                AdditionalCost = Device.RentalPrice;

            var totalPrice = Device.RentalPrice + AdditionalCost;
            return totalPrice;
        }
        public override string ToString()
        {
            return $"[{id}] {User.FirstName} {User.LastName} - {Device.Name} status: {(IsActive ? "Not returned" : "Returned")}, deadline: {Deadline}";
        }
    }
}
