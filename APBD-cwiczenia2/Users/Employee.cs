namespace APBD_cwiczenia2.Users
{
    public class Employee(int id, string firstName, string lastName, decimal salary) : User(id, firstName, lastName)
    {
        public decimal Salary { get; } = salary;
        public override string ToString()
        {
            return $"{BasePrint()} salary: {Salary} zł";
        }
    }
}
