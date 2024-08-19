namespace MotoApp2;

using Microsoft.EntityFrameworkCore;
using MotoApp2.Data;
using MotoApp2.Entities;
using MotoApp2.Repositories;
using MotoApp2.Repositories.Extension;
using MotoApp2.Entities.Extensions;
using System;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main()
    {

        var inOutFile = new InOutExtension();
        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext());
        inOutFile.AddFileToSqlRepository(employeeRepository);

        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Witam w programie rejestracji pracowników i managerów  ║");
        Console.WriteLine("║  PROSZĘ POSTĘPOWAĆ ZGODNIE Z WYŚWIETLANYM MENU !!!!!   ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        int counter1 = 0;
        int p = 0;
        int p2 = 0;
        bool ExitMenu = true;
        while (ExitMenu)
        {
            counter1++;
            //MENU GŁÓWNE
            if (counter1 == 1)
            {
                p = 6;
                p2 = 8;
            }
            else { p = 2; p2 = 4; }
            WriteLineColor(ConsoleColor.Blue);
            Console.SetCursorPosition(1, p); ;
            Console.WriteLine("MENU GŁÓWNE ");
            Console.ResetColor();
            WriteLineColor(ConsoleColor.Red);
            Console.SetCursorPosition(0, p2);
            Console.WriteLine(" 1 - Wprowadzanie pracowników:\n" +
                                " 2 - Rejestr pracowników;\n" +
                                 " X lub x koniec programu ");
            Console.ResetColor();

            var input = Console.ReadLine();
            var input2 = input.ToUpper();
            switch (input2)
            {
                case "1":
                    
                    AddEmployeeToSql();
                    break;

                case "2":

                    EmployeeRegister(employeeRepository);
                    break;
                case "X":
                    ExitMenu = false;
                    break;

                default:

                    Console.WriteLine("Niepoprawny wybór.\n");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
            }

        }
        inOutFile.AddEmployeeTooFile(employeeRepository);
        Console.WriteLine("\n\n Dziękujemy za skożystanie z aplikacji :) ");
        Thread.Sleep(4000);
        Console.Clear();
    }
    private static void AddEmployeeToSql()
    {

        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext(), EmployeeAded);

        Console.Clear();
        bool ExitMenu2 = true;
        while (ExitMenu2)
        {

            // DODAWAIE PRACOWNIKÓW
            Console.Clear();
            WriteLineColor(ConsoleColor.Green);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("MENU WYBORU PRACOWNIKÓW I MANAGERÓW ");
            Console.ResetColor();
            WriteLineColor(ConsoleColor.Red);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(" 1 - Lista Pracowników\n" +
                                " 2 - Dodawanie Pracownika\n" +
                                " 3 - Dodawanie Managera\n" +
                                " X lub x Powrót do MENU głównego ");
            Console.ResetColor();

            var userInput2 = Console.ReadLine();
            switch (userInput2)
            {
                case "1":
                    EmployeeList(employeeRepository);
                    break;
                case "2":
                    AddEmployee();
                    break;
                case "3":
                    AddManager();
                    break;

                case "x":
                case "X":
                    ExitMenu2 = false;
                    break;
                default:
                    Console.WriteLine("Nie poprawny wybór");
                    break;
            }
        }

    }

    static void EmployeeAded(object item)
    {
        var employee = (Employee)item;
        Console.WriteLine($"Dodano nowego pracownika {employee.FirstName}, {employee.SurName}");
    }

    static void AddEmployee()
    {
        void EmployeeRepository_ItemAded(object? sender, Employee e)
        {
            Console.WriteLine($"Dodano => {e.FirstName} from {sender?.GetType().Name}");
        }

        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext(), EmployeeAded);
        employeeRepository.ItemAded += EmployeeRepository_ItemAded;
        while (true)
        {
            string name = AddName("imię Pracownika");
            if (name == "X")
            { break; }
            Console.Clear();
            string name2 = AddName("nazwisko Pracownika");
            Console.Clear();
            var employees = new[]
            {
         new Employee { FirstName = name, SurName = name2},
        };

            employeeRepository.AddBach(employees);
        }

    }
    static void AddManager()
    {
        //var itemAdded = new Action<Manager>(EmployeeAded);
        var employeeRepository = new SqlRepository<Manager>(new MotoApp2DbContext(), EmployeeAded);
        void EmployeeRepository_ItemAded(object? sender, Manager e)
        {
            Console.WriteLine($"Dodano => {e.FirstName} from {sender?.GetType().Name}");
        }
        employeeRepository.ItemAded += EmployeeRepository_ItemAded;
        while (true)
        {
            string name = AddName("imię Managera");
            if (name == "X")
            { break; }
            Console.Clear();
            string name2 = AddName("nazwisko Managera");
            Console.Clear();
            var employees = new[]
            {
            new Manager
            {FirstName = name, SurName = name2},
            };
            employeeRepository.AddBach(employees) ;
        }
    }

    static void EmployeeRegister(IReadRepository<IEntity> employeeRepository)
    {
        Console.Clear();
        bool ExitMenu2 = true;
        while (ExitMenu2)
        {
            // DODAWAIE PRACOWNIKÓW
            Console.Clear();
            WriteLineColor(ConsoleColor.Green);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("MENU WYBORU PRACOWNIKÓW I MANAGERÓW ");
            Console.ResetColor();
            WriteLineColor(ConsoleColor.Red);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(" 1 - Poprawianie danych Prcownika\n" +
                                " 2 - Usuwanie Prcownika\n" +
                                " X lub x Powrót do MENU głównego ");
            Console.ResetColor();

            var userInput2 = Console.ReadLine();
            switch (userInput2)
            {
                case "1":
                    UppDateEmoloyee();
                    break;
                case "2":
                    RemoveEmployee();
                    break;

                case "x":
                case "X":
                    ExitMenu2 = false;
                    break;
                default:
                    Console.WriteLine("Nie poprawny wybór");
                    break;
            }
        }
        Console.Clear();
    }

    static void UppDateEmoloyee()
    {
        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext());
        EmployeeList(employeeRepository);
        var count = employeeRepository.GetAll().Count();
        if (count != 0)
        {
            Console.WriteLine();
            string id = AddName("Id");
            if (int.TryParse(id, out int id2))
            {
                var user = employeeRepository.GetById(id2);
                Console.WriteLine(user);
                while (true)
                {
                    string name = AddName("Nowe imię Pracownika lub X aby wrócić do MENU");
                    if (name == "X")
                    { AddEmployeeToSql(); }
                    Console.Clear();
                    string name2 = AddName("Nowe nazwisko Pracownika");
                    Console.Clear();
                    user.FirstName = name;
                    employeeRepository.UpDateEmployee(user);
                    user.SurName = name2;
                    employeeRepository.UpDateEmployee(user);
                    EmployeeList(employeeRepository);
                    Console.ReadLine();
                    break;
                }

            }
            else
            {
                Console.WriteLine("nie poprawna wartość");
            }

        }
        else
        {
            AddEmployeeToSql();
        }
    }

    static void EmployeeList(IReadRepository<Employee> employeeRepository)
    {
        List<string> employees = new List<string>();

        var items = employeeRepository.GetAll();
        int count = items.Count();
        if (count == 0)
        {
            Console.WriteLine("katalog jest pusty");
            Console.ReadKey();
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString2());
            }
        }
            Console.ReadKey();
    }



        

    

    static void EmployeeRemove(object item)
    {
        var employee = (Employee)item;
        Console.WriteLine($"Usunięto Pracowika  {employee.FirstName}, {employee.SurName}");
    }
    static void RemoveEmployee()
    {
        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext());
        EmployeeList(employeeRepository);
        var count2 = employeeRepository.GetAll().Count();
        if (count2 > 0)
        {
            string numb = AddName($"Numer do usunięcia");
            if (int.TryParse(numb, out int result)) ;
            {
                var items = employeeRepository.GetAll();
                if (result > 0)
                {
                    employeeRepository.RemoveDevice(new Employee { Id = result }); ;
                    employeeRepository.Save();
                }
                else
                {
                    WriteLineColor(ConsoleColor.Red);
                    Console.WriteLine("Wartość z poza zakresu długości listy");
                }
            }
        }
        else { AddEmployeeToSql(); }

        Console.ReadKey();
        Console.Clear();
    }
    static void RemoveList()
    {
        var employeeRepository = new SqlRepository<Employee>(new MotoApp2DbContext());
        EmployeeList(employeeRepository);
        var items = employeeRepository.GetAll();
        int count = items.Count();
        for (int i = 1; i <= count; i++)
        {
            employeeRepository.Remove(new Employee { Id = i }); ;
            employeeRepository.Save();
        }
    }

    static void RemoveEmployeeList(Employee item)
    {

        Console.WriteLine($"Usunieto pozycję {item}");
    }
    static string AddName(string text)
    {
        WriteLineColor(ConsoleColor.Green);
        Console.WriteLine($"Podaj {text}");
        string name = Console.ReadLine();
        string name1 = name.ToUpper();
        return name1;
    }
    private static void WriteLineColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;

    }
}
