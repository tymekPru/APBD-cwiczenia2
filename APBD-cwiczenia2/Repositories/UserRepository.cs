using APBD_cwiczenia2.Devices;
using APBD_cwiczenia2.Users;

namespace APBD_cwiczenia2.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = [];
        private int _nextId = 1;
        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public List<User> GetAll() => _users;
        public int GetNextId() => _nextId;
        public Student AddStudent(string firstName, string lastName, string indexNumber)
        {
            var student = new Student(_nextId++, firstName, lastName, indexNumber);
            _users.Add(student);
            return student;
        }
        public Employee AddEmployee(string firstName, string lastName, decimal salary)
        {
            var employee = new Employee(_nextId++, firstName, lastName, salary);
            _users.Add(employee);
            return employee;
        }
        public void ListAllUsers()
        {
            _users
                .ForEach(Console.WriteLine);
        }
        public void Restore(List<User> data, int nextId)
        {
            _users.Clear();
            _users.AddRange(data);
            _nextId = nextId;
        }
    }
}