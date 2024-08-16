using Microsoft.EntityFrameworkCore;

using MotoApp2.Entities;
using MotoApp2.Repository;

namespace MotoApp2.Repositories;

public class ListRepository<T> : IRepository <T>
    where T: class, IEntity
    
{
    protected readonly List<T> _items = new();

   
    public T? GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }

    public IEnumerable<T> GetAll() => _items.ToList();

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
       //save is not required with List
    }
    
}
