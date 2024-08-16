namespace MotoApp2.Data.Repositories
{
  
    using MotoApp2.Entities;

    public class EmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
        }

        public void Save()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine(employee);
            }
        }

        public Employee GetById(int id) => _employees.Single(item => item.Id == id);

    }
}
