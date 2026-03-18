namespace APBD_cwiczenia2.Users
{
    public class Student(int id, string firstName, string lastName, string indexNumber) : User(id, firstName, lastName)
    {
        public string IndexNumber { get; } = indexNumber;
        public override string ToString()
        {
            return $"{BasePrint()} student: {IndexNumber}";
        }
    }
}
