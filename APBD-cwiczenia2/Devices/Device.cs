using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace APBD_cwiczenia2.Devices
{
    [JsonDerivedType(typeof(Laptop), typeDiscriminator: "laptop")]
    [JsonDerivedType(typeof(Phone), typeDiscriminator: "phone")]
    [JsonDerivedType(typeof(Camera), typeDiscriminator: "camera")]
    public abstract class Device(int id, string name, decimal rentalPrice, string description)
    {
        public int Id = id;
        public string Name { get; } = name;
        public Availability Availability { get; private set; } = Availability.Available;
        public decimal RentalPrice { get; } = rentalPrice;
        public string Description { get; } = description;
        protected string BasePrint()
        {
            return $"[{id}:{GetType()}] {Name} {Availability} {RentalPrice} zł, ({Description})";
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
