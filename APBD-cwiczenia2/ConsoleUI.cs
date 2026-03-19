using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Repositories;
using APBD_cwiczenia2.Users;

namespace APBD_cwiczenia2
{
    public class ConsoleUI(DeviceRepository dr, UserRepository ur, RentalRepository rr, ReportService rs)
    {
        private readonly DeviceRepository _deviceRepo = dr;
        private readonly UserRepository _userRepo = ur;
        private readonly RentalRepository _rentalRepo = rr;
        private readonly ReportService _reportService = rs;
        public void Run()
        {
            Console.WriteLine("Czy chcesz aby w systemie pojawiły się przykładowe dane? (y/n)");
            var genereateData = ReadBool();
            if (genereateData)
                GenerateExampleData();

            while (true)
            {
                Console.WriteLine("\n=== SYSTEM WYPOŻYCZALNI APBD ===");
                Console.WriteLine("1. Zarządzanie sprzętem (Dodaj/Lista)");
                Console.WriteLine("2. Zarządzanie użytkownikami");
                Console.WriteLine("3. Wypożyczenia i zwroty");
                Console.WriteLine("4. Generuj raport");
                Console.WriteLine("0. Wyjście");
                Console.Write("\nWybierz opcję (0-4): ");

                var choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1": DeviceMenu(); break;
                        case "2": UserMenu(); break;
                        case "3": RentalMenu(); break;
                        case "4": _reportService.PrintReport(); break;
                        case "0": return;
                        default: Console.WriteLine("Błędna opcja!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"BŁĄD: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
        private void DeviceMenu()
        {
            Console.Clear();
            Console.WriteLine("\n1. Lista sprzętu");
            Console.WriteLine("2. Lista dostępnego sprzętu");
            Console.WriteLine("3. Dodaj Laptop");
            Console.WriteLine("4. Dodaj Telefon");
            Console.WriteLine("5. Dodaj Aparat");
            var choice = Console.ReadLine();

            if (choice == "1") _deviceRepo.ListAllDevices();
            if (choice == "2") _deviceRepo.ListAvailableDevices();
            if (choice == "3" || choice == "4" || choice == "5")
            {
                Console.WriteLine("Nazwa: "); string name = ReadString();
                Console.WriteLine("Cena wynajmu (zł): "); decimal rentalPrice = ReadDecimal();
                Console.WriteLine("Opis: "); string description = ReadString();
                if (choice == "3")
                {
                    Console.WriteLine("Ilość RAM(GB): "); int ramGb = ReadInt();
                    Console.WriteLine("Rozdzielczoźć: "); ScreenResolution sr = ReadEnum<ScreenResolution>();
                    _deviceRepo.AddLaptop(name, rentalPrice, description, ramGb, sr);
                }
                if (choice == "4")
                {
                    Console.WriteLine("Wielkość baterii(mAh): "); int mAh = ReadInt();
                    Console.WriteLine("OS: "); OS os = ReadEnum<OS>();
                    _deviceRepo.AddPhone(name, rentalPrice, description, mAh, os);
                }
                if (choice == "5")
                {
                    Console.WriteLine("Ilość megapikseli: "); int mpx = ReadInt();
                    Console.WriteLine("Czy ma opcję nagrywania (y/n): "); bool hasVideoRecording = ReadBool();
                    _deviceRepo.AddCamera(name, rentalPrice, description, mpx, hasVideoRecording);
                }
            }
        }
        private void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("\n=== ZARZĄDZANIE UŻYTKOWNIKAMI ===");
            Console.WriteLine("1. Lista wszystkich użytkowników");
            Console.WriteLine("2. Dodaj Studenta");
            Console.WriteLine("3. Dodaj Pracownika");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            if (choice == "1") _userRepo.ListAllUsers();
            if (choice == "2" || choice == "3")
            {
                Console.Write("Imię: "); string fn = ReadString();
                Console.Write("Nazwisko: "); string ln = ReadString();

                if (choice == "2")
                {
                    Console.Write("Numer indeksu: "); string index = ReadString();
                    _userRepo.AddStudent(fn, ln, index);
                }
                else
                {
                    Console.Write("Pensja: "); decimal salary = ReadDecimal();
                    _userRepo.AddEmployee(fn, ln, salary);
                }
                Console.WriteLine("Dodano użytkownika!");
            }
        }
        private void RentalMenu()
        {
            Console.Clear();
            Console.WriteLine("\n=== WYPOŻYCZENIA I ZWROTY ===");
            Console.WriteLine("1. Nowe wypożyczenie");
            Console.WriteLine("2. Zwrot sprzętu");
            Console.WriteLine("3. Lista wszystkich wypożyczeń");
            Console.WriteLine("4. Lista zaległych wypożyczeń (po terminie)");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _deviceRepo.ListAvailableDevices();
                    Console.Write("Podaj ID sprzętu: "); int devId = ReadInt();
                    var device = _deviceRepo.GetById(devId);

                    _userRepo.ListAllUsers();
                    Console.Write("Podaj ID użytkownika: "); int userId = ReadInt();
                    var user = _userRepo.GetById(userId);

                    if (device == null || user == null)
                    {
                        Console.WriteLine("Błędne ID sprzętu lub użytkownika!");
                        return;
                    }

                    Console.WriteLine("Na ile dni wypożyczyć?");
                    int days = ReadInt();

                    var rental = _rentalRepo.RentDevice(device, user, DateTime.Now.AddDays(days));
                    Console.WriteLine($"Sukces! ID wypożyczenia: {rental.Id}");
                    break;

                case "2":
                    _rentalRepo.ListAllRentals();
                    Console.Write("Podaj ID wypożyczenia do zwrotu: ");
                    int rentId = ReadInt();
                    var r = _rentalRepo.GetById(rentId);

                    if (r != null)
                    {
                        decimal cost = r.ReturnDevice();
                        Console.WriteLine($"Sprzęt zwrócony. Koszt całkowity: {cost} zł.");
                    }
                    else Console.WriteLine("Nie znaleziono takiego wypożyczenia.");
                    break;

                case "3":
                    _rentalRepo.ListAllRentals();
                    break;

                case "4":
                    _rentalRepo.ListOverdueRentals();
                    break;
            }
        }
        private static bool ReadBool()
        {
            while (true)
            {
                try
                {
                    var line = Console.ReadLine();

                    if (line.ToLowerInvariant().Equals("y"))
                        return true;
                    if (line.ToLowerInvariant().Equals("n"))
                        return false;
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
                catch
                {
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
            }
        }
        private static decimal ReadDecimal()
        {
            while (true)
            {
                try
                {
                    var line = Console.ReadLine();
                    if (decimal.TryParse(line, out decimal value))
                        return value;
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
                catch
                {
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }

            }
        }
        private static int ReadInt()
        {
            while (true)
            {
                try
                {
                    var line = Console.ReadLine();
                    if (int.TryParse(line, out int value))
                        return value;
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
                catch
                {
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
            }
        }
        private static string ReadString()
        {
            while (true)
            {
                try
                {
                    var line = Console.ReadLine();
                    return line ?? "";
                }
                catch
                {
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
            }
        }
        private T ReadEnum<T>() where T : struct, Enum
        {
            T[] values = (T[])Enum.GetValues(typeof(T));

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {values[i]}");
            }

            while (true)
            {
                try
                {
                    Console.Write("Wybierz numer: ");
                    int index = ReadInt();

                    if (index > 0 && index <= values.Length)
                    {
                        return values[index - 1];
                    }

                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
                catch
                {
                    Console.WriteLine("Podano błędną wartość. Spróbuj ponownie.");
                }
            }
        }
        private void GenerateExampleData()
        {

            var laptop = _deviceRepo.AddLaptop("MacBook Pro 14", 150.00m, "M3 Pro, gwiezdna czerń", 18, ScreenResolution.FullHD);
            _deviceRepo.AddLaptop("Dell XPS 13", 120.00m, "Ultra-mobilny laptop do pracy", 16, ScreenResolution.QHD);
            _deviceRepo.AddCamera("Sony A7 IV", 200.00m, "Pełnoklatkowy bezlusterkowiec", 33, true);
            _deviceRepo.AddPhone("Samsung Galaxy S24", 95.00m, "Ekran 120Hz, świetny aparat", 4000, OS.Android);
            _deviceRepo.AddPhone("iPhone 15 Pro", 110.00m, "Tytanowa obudowa, USB-C", 3274, OS.iOS);

            var student = _userRepo.AddStudent("Jan", "Kowalski", "s12345");
            _userRepo.AddStudent("Anna", "Nowak", "s54321");
            _userRepo.AddEmployee("Piotr", "Wiśniewski", 8500m);

            _rentalRepo.RentDevice(laptop, student, DateTime.Now.AddDays(7));
        }
    }
}