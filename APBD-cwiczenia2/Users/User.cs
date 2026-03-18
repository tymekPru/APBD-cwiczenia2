namespace APBD_cwiczenia2.Users
{
    public abstract class User(int id, string firstName, string lastName)
    {
        public int Id { get; }
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        protected string BasePrint()
        {
            return $"[{id}] {FirstName} {LastName}";
        }
    }
}
