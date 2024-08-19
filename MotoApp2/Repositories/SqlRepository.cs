using MotoApp2.Repositories;
using Microsoft.EntityFrameworkCore;
using MotoApp2.Entities;
using MotoApp2.Repository;
using System.Security.Cryptography.X509Certificates;

namespace MotoApp2.Repositories;
//public delegate void ItemAdedd<in T>(T item);

public class SqlRepository<T> : IRepository<T> where T : class , IEntity,new()
{
    private readonly DbSet<T> _dbSet;  // to też jest zasób z MotoApp2DbContext
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAdedCallback;
  
    public SqlRepository(DbContext dbContext ,Action<T>? itemAdedCalback = null)// dbContext to zasób  
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAdedCallback = itemAdedCalback;
        
    }

    public event EventHandler<T> ItemAded;

    public IEnumerable<T> GetAll() => _dbSet.OrderBy(x => x.Id).ToList();

    public T? GetById(int id) 
    {
        return _dbSet.Find(id);
    }

    public void Add(T item )
    {
        
        
        _dbSet.Add(item );
        _itemAdedCallback?.Invoke( item );
        ItemAded?.Invoke(this, item);
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
       
    }

    public void Save()
    {
       _dbContext.SaveChanges();
    }
    public void RemoveDevice(T item)
    {
        T items = _dbSet.FirstOrDefault(c => c.Id == item.Id);
        if (items != null)
        {
            _dbSet.Remove(items); //usuwamy 
            _dbContext.SaveChanges(); //zapisujemy zmiany w bazie danych
            _itemAdedCallback?.Invoke(item);
            Console.WriteLine("Wpis został usunięty");

        }
        else
        {
            Console.WriteLine("Nie znaleziono urządzenia o podanym Id.");
            Console.ReadLine();
        }
    }
    public void UpDateEmployee(T item)
    {
        _dbSet.Update(item);
        Save();
    }
}
