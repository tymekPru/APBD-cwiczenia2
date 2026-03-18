using APBD_cwiczenia2.Repositories;

namespace APBD_cwiczenia2
{
    public class ReportService(DeviceRepository dr, RentalRepository rr, UserRepository ur)
    {
        private readonly DeviceRepository _deviceRepo = dr;
        private readonly RentalRepository _rentalRepo = rr;
        private readonly UserRepository _userRepo = ur;
        public void PrintReport()
        {
            Console.WriteLine("Listing all devices.");
            _deviceRepo.ListAllDevices();

            Console.WriteLine("Listing all rentals.");
            _rentalRepo.ListAllRentals();

            Console.WriteLine("Listing all users.");
            _userRepo.ListAllUsers();
        }
    }
}