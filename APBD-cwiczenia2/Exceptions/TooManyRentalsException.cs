namespace APBD_cwiczenia2.Exceptions
{
    public class TooManyRentalsException(int maxRentals) : Exception($"User has at least {maxRentals} active rentals. Cannot rent any more devices.")
    {
    }
}