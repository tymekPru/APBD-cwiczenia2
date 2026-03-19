using System.Runtime.InteropServices;
using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;
using APBD_cwiczenia2.Exceptions;
using System.Xml;

namespace APBD_cwiczenia2.Repositories
{
    public class RentalRepository
    {
        private readonly List<Rental> _rentals = [];
        private int _nextId = 1;
        private readonly int MaxRentalsForStudent = 2;
        private readonly int MaxRentalsForEmployee = 5;
        public Rental GetById(int id) => _rentals.FirstOrDefault(r => r.Id == id);
        public List<Rental> GetAll() => _rentals;
        public int GetNextId() => _nextId;
        public Rental RentDevice(Device device, User user, DateTime deadline)
        {
            if (device.Availability == Availability.Unavailable)
                throw new DeviceUnavailableException();
            if (user is Student student && _rentals.Count(x => x.User == student && x.IsActive) >= MaxRentalsForStudent)
                throw new TooManyRentalsException(MaxRentalsForStudent);

            if (user is Employee employee && _rentals.Count(x => x.User == employee && x.IsActive) >= MaxRentalsForEmployee)
                throw new TooManyRentalsException(MaxRentalsForEmployee);

            device.SetUnavailable();
            var rental = new Rental(_nextId++, device, user, deadline);
            _rentals.Add(rental);
            return rental;
        }
        public void ListAllRentals()
        {
            _rentals.
                ForEach(Console.WriteLine);
        }
        public void ListForUser(User user)
        {
            _rentals
                .Where(x => x.User == user)
                .ToList()
                .ForEach(Console.WriteLine);
        }
        public void ListOverdueRentals()
        {
            _rentals
                .Where(x => x.ReturnDate == null && x.Deadline < DateTime.Now)
                .ToList()
                .ForEach(Console.WriteLine);
        }
        public void Restore(List<Rental> data, int nextId)
        {
            _rentals.Clear();
            _rentals.AddRange(data);
            _nextId = nextId;
        }
    }
}