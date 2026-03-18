using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;

namespace APBD_cwiczenia2.Devices
{
    public abstract class Device(int id, string name, decimal rentalPrice, string description)
    {
        public int Id = id;
        public string Name { get; } = name;
        public Availability Availability { get; private set; } = Availability.Available;
        public decimal RentalPrice { get; } = rentalPrice;
        public string Description { get; } = description;
        protected string BasePrint()
        {
            return $"[{id}:{Name}] {Availability} {RentalPrice} zł, ({Description})";
        }
        public void SetUnavailable() => Availability = Availability.Unavailable;
        public void SetAvailable() => Availability = Availability.Available;
    }
    public enum Availability
    {
        Available,
        Unavailable
    }
}
