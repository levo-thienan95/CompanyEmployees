using System.Linq.Expressions;

namespace CompanyEmployees.Core.Domain.Repositories;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> Get(Expression<Func<T, bool>> predicate,bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}