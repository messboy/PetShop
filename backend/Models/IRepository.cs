using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> GetBySql(string query, params object[] patameters);

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);


    }
}
