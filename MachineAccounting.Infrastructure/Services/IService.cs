using System.Collections.Generic;
using System.Threading.Tasks;
using MachineAccounting.DataContext.Models;

namespace MachineAccounting.Infrastructure.Services
{
    public interface IService<T> where T: IEntity
    {
        T Get(int id);
        T New();

        bool Exists(int id);
        Task<T> GetAsync(int id); 
        List<T> GetList();
        Task<List<T>> GetListAsync();

        bool Create(T entity);
        Task<bool> CreateAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);

    }
}