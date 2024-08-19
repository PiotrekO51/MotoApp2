using MotoApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp2.Entities.Extensions;

public class InOutExtension
{
    public  void AddEmployeeTooFile(IReadRepository<IEntity> sqlRepository)

    {
        File.Delete("Employe_Data.txt");
        var items = sqlRepository.GetAll();
        if (items != null)
            using (var writer = File.AppendText("Employe_Data.txt"))
                foreach (var item in items)
                {
                    writer.WriteLine(item);
                }

        else
        { Console.WriteLine("Nie poprawna wartość"); }

    }
    public  void AddFileToSqlRepository(IWriteRepository<Employee> sqlRepository)
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
                    sqlRepository.Add(new Employee { Id = id2, FirstName = name, SurName = surname });
                    line = reader.ReadLine();
                }
                sqlRepository.Save();
            }
        }
        else { Console.WriteLine("Brak pliku"); }
    }

}
