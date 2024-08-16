
namespace MotoApp2.Data; 
using Microsoft.EntityFrameworkCore;
using MotoApp2.Entities;


public class MotoApp2DbContext: DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    
    public DbSet<BusinesPartner> BusinesPartner => Set<BusinesPartner>();   

    public DbSet<Manager> Manager => Set<Manager>();

    // tworzenie nazwy katalogu w pamięcie do zapisu i odczytu danych
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDB");
    }
}
