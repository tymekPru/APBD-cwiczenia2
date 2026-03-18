// See https://aka.ms/new-console-template for more information
using APBD_cwiczenia2;
using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Repositories;

Console.WriteLine("Hello, World!");

var repo = new DeviceRepository();
repo.AddLaptop("MacBook Pro 14", 150.00m, "M3 Pro, Gwiezdna czerń", 18, ScreenResolution.FullHD);
repo.AddLaptop("Lenovo Legion 5", 90.50m, "Laptop gamingowy z RTX 4060", 32, ScreenResolution.FullHD);
repo.AddLaptop("Dell XPS 13", 120.00m, "Ultra-mobilny laptop do pracy", 16, ScreenResolution.QHD);

// Dodawanie Aparatów/Kamer
repo.AddCamera("Sony A7 IV", 200.00m, "Pełnoklatkowy bezlusterkowiec", 33, true);
repo.AddCamera("Canon EOS R6", 180.00m, "Profesjonalne body", 20, true);
repo.AddCamera("GoPro Hero 12", 50.00m, "Kamera sportowa", 27, true);

// Dodawanie Telefonów
repo.AddPhone("iPhone 15 Pro", 110.00m, "Tytanowa obudowa, USB-C", 3274, OS.iOS);
repo.AddPhone("Samsung Galaxy S24", 95.00m, "Ekran 120Hz, świetny aparat", 4000, OS.Android);
repo.AddPhone("Google Pixel 8", 85.00m, "Czysty Android i AI", 4575, OS.Android);

repo.ListDevices();

