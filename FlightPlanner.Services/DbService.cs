using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class DbService : IDbService
    {
        protected IFlightPlannerDbContext _dbContext;

        public DbService(IFlightPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
           return _dbContext.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _dbContext.Set<T>().Where(w => w.Id == id);
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _dbContext.Set<T>().SingleOrDefault(w => w.Id.Equals(id));
        }

        public void Create<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteRange<T>() where T : Entity
        {
            _dbContext.Set<T>().RemoveRange(_dbContext.Set<T>());
            _dbContext.SaveChanges();
        }
    }
}
