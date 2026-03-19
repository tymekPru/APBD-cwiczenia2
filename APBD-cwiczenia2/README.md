#System Wypożyczalni Sprzętu - APBD Cw2

Prosty system do zarządzania wypożyczalniami elektroniki (laptopy, telefony, aparaty) dla studentów i pracowników uczelni.

Ekstensje klasy trzymamy w Repository, żeby oddzielić logikę przechowywania danych od interfejsu użytkownika.

Dziedziczenie: Sprzęty (Device) i użytkownicy (User) to klasy abstrakcyjne. Klasy dziedziczące mają swoje dodatkowe pola.

Stworzyłem własne wyjątki (DeviceUnavailableException, TooManyRentalsException), żeby czytelnie obsługiwać błędy biznesowe.

Dane zapisują się automatycznie do JSON-a w folderze /save przy wyjściu z programu i wczytują przy starcie. Użyłem ReferenceHandler.Preserve, żeby po wczytaniu relacje między wypożyczeniem a użytkownikiem/sprzętem działały na tych samych obiektach.

w interfejsie tekstowym mamy proste menu konsolowe z walidacją wejścia

**Projekt pisany pod .NET 10**

Otwórz terminal w folderze projektu.
dotnet run

_Przy pierwszym uruchomieniu możesz wybrać opcję wygenerowania danych testowych, żeby nie klikać wszystkiego ręcznie._

Pliki:
Devices/, Users/ - modele danych
Repositories/ - zarządzanie listami obiektów
AppStateLoader.cs - obsługa zapisu/odczytu JSON
ConsoleUI.cs - cała obsługa menu
