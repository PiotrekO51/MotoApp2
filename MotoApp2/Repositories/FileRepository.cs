

using Microsoft.EntityFrameworkCore;
using MotoApp2.Data.Repositories;
using MotoApp2.Entities;

namespace MotoApp2.Repositories;

public class FileRepository: Employee
{
    public void AddEmployeeTooFile(IReadRepository<Employee> employeeRepository)
    {
        File.Delete("Employe_Data.txt");
        var items = employeeRepository.GetAll();
        if (items != null)
            using (var writer = File.AppendText("Employe_Data.txt"))
                foreach (var item in items)
                {
                    writer.WriteLine(item);
                }

        else
        { Console.WriteLine("Nie poprawna wartość"); }

    }
    public void AddFileToSqlRepository(IWriteRepository<Employee> employeeRepository)
    {
        if (File.Exists("Employe_Data.txt"))
        {
            using (var reader = File.OpenText("Employe_Data.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] pole = line.Split(',');
                    int id2 = int.Parse(pole[0]);
                    string name = pole[1];
                    string surname = pole[2];
                    employeeRepository.Add(new Employee { Id = id2,FirstName = name, SurName=surname});
                    line = reader.ReadLine();
                }
                employeeRepository.Save();
            }
        }
        else { Console.WriteLine("Brak pliku");}
    }
}
