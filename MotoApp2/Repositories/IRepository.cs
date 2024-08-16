using Microsoft.EntityFrameworkCore;
using MotoApp2.Entities;

using MotoApp2.Repositories;


namespace MotoApp2.Repository;

public interface IRepository<T>: IReadRepository<T>,IWriteRepository<T> 
    where T : class, IEntity
{ 
    
}
