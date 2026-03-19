using APBD_cwiczenia2;
using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Exceptions;
using APBD_cwiczenia2.Repositories;
using APBD_cwiczenia2.Users;

var deviceRepo = new DeviceRepository();
var userRepo = new UserRepository();
var rentalRepo = new RentalRepository();
var reportService = new ReportService(deviceRepo, rentalRepo, userRepo);
var appStateLoader = new AppStateLoader();
appStateLoader.Load(deviceRepo, userRepo, rentalRepo);

bool startUI = true;

if (startUI)
{
    var consoleUI = new ConsoleUI(deviceRepo, userRepo, rentalRepo, reportService);
    consoleUI.Run();
}
else
{
    Console.WriteLine("Dodanie kilku sprzętów różnych typów");
    var laptop1 = deviceRepo.AddLaptop("MacBook Pro 14", 150.00m, "M3 Pro, gwiezdna czerń", 18, ScreenResolution.FullHD);
    var laptop2 = deviceRepo.AddLaptop("Dell XPS 13", 120.00m, "Ultra-mobilny laptop do pracy", 16, ScreenResolution.QHD);
    var camera1 = deviceRepo.AddCamera("Sony A7 IV", 200.00m, "Pełnoklatkowy bezlusterkowiec", 33, true);
    var phone1 = deviceRepo.AddPhone("Samsung Galaxy S24", 95.00m, "Ekran 120Hz, świetny aparat", 4000, OS.Android);
    var phone2 = deviceRepo.AddPhone("iPhone 15 Pro", 110.00m, "Tytanowa obudowa, USB-C", 3274, OS.iOS);
    deviceRepo.ListAllDevices();
    Console.WriteLine();

    Console.WriteLine("Dodanie kilku użytkowników różnych typów");
    var student1 = userRepo.AddStudent("Jan", "Kowalski", "s12345");
    var student2 = userRepo.AddStudent("Anna", "Nowak", "s54321");
    var employee1 = userRepo.AddEmployee("Piotr", "Wiśniewski", 8500m);
    userRepo.ListAllUsers();
    Console.WriteLine();

    Console.WriteLine("Poprawne wypożyczenie sprzętu");
    var rentalOnTime = rentalRepo.RentDevice(laptop1, student1, DateTime.Now.AddDays(7));
    Console.WriteLine($"Utworzono wypożyczenie: {rentalOnTime}");
    Console.WriteLine();

    Console.WriteLine("Próba wykonania niepoprawnej operacji");
    try
    {
        rentalRepo.RentDevice(laptop1, employee1, DateTime.Now.AddDays(3));
    }
    catch (DeviceUnavailableException ex)
    {
        Console.WriteLine($"Błąd (sprzęt niedostępny): {ex.Message}");
    }

    try
    {
        rentalRepo.RentDevice(phone1, student1, DateTime.Now.AddDays(5));
        rentalRepo.RentDevice(camera1, student1, DateTime.Now.AddDays(5));
        rentalRepo.RentDevice(laptop2, student1, DateTime.Now.AddDays(5));
    }
    catch (TooManyRentalsException ex)
    {
        Console.WriteLine($"Błąd (przekroczony limit): {ex.Message}");
    }
    Console.WriteLine();

    Console.WriteLine("Zwrot sprzętu w terminie");
    var totalOnTime = rentalOnTime.ReturnDevice(DateTime.Now.AddDays(3));
    Console.WriteLine($"Zwrot: {rentalOnTime.Device.Name}, opłata końcowa: {totalOnTime} zł (kara: {rentalOnTime.AdditionalCost} zł)");
    Console.WriteLine();

    Console.WriteLine("Zwrot opóźniony skutkujący naliczeniem kary");
    var rentalLate = rentalRepo.RentDevice(phone2, employee1, DateTime.Now.AddDays(2));
    var totalLate = rentalLate.ReturnDevice(DateTime.Now.AddDays(5));
    Console.WriteLine($"Zwrot: {rentalLate.Device.Name}, opłata końcowa: {totalLate} zł (kara: {rentalLate.AdditionalCost} zł)");
    Console.WriteLine();

    Console.WriteLine("Raport końcowy o stanie systemu");
    reportService.PrintReport();
}

Console.WriteLine("Zapisywanie danych...");
appStateLoader.Save(deviceRepo, userRepo, rentalRepo);