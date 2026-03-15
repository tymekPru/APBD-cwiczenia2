namespace APBD_cwiczenia2.Devices
{
    public abstract class Device
    {
        protected readonly int Id = GenerateId();
        private static readonly List<int> ids = [];

        public string Name { get; set; }
        public Availability Availability { get; private set; } = Availability.Available;
        public decimal RentalPrice { get; set; }
        public string? Description { get; set; }

        private static int GenerateId()
        {
            if (ids.Count == 0)
            {
                ids.Add(1);
                return 1;
            }
            var newId = ids.Max() + 1;
            ids.Add(newId);
            return newId;
        }
    }
    public enum Availability
    {
        Available,
        Unavailable
    }
}
