using System.Linq.Expressions;
using CompanyEmployees.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Persistence;

public abstract class RepositoryBase<T>:IRepositoryBase<T> where T:class
{
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }
    
    public IQueryable<T> GetAll(bool trackChanges)
    {
        if (!trackChanges)
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        return RepositoryContext.Set<T>();
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (!trackChanges)
        {
           return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        return RepositoryContext.Set<T>().Where(expression);
    }

    public void Add(T entity)
    { 
        RepositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
    }
}