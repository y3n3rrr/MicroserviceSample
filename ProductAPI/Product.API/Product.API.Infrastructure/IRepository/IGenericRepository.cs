using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.API.Infrastructure
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}