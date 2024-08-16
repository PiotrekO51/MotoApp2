using MotoApp2.Entities;
using Microsoft.EntityFrameworkCore;
namespace MotoApp2.Repositories;

public interface IReadRepository<out T> where T : class, IEntity

{
    IEnumerable<T> GetAll();

    T? GetById(int id);
}
