using System.Text.Json.Serialization;
namespace APBD_cwiczenia2.Users
{
    [JsonDerivedType(typeof(Student), typeDiscriminator: "student")]
    [JsonDerivedType(typeof(Employee), typeDiscriminator: "employee")]
    public abstract class User(int id, string firstName, string lastName)
    {
        public int Id { get; }
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        protected string BasePrint()
        {
            return $"[{id}:{GetType()}] {FirstName} {LastName}";
        }
    }
}
