
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineAccounting.DataContext;
using MachineAccounting.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineAccounting.Infrastructure.Services
{
    public interface IMachineService : IService<Machine>
    {
        List<MachineType> GetMachineTypeList();
        List<Storage> GetStorageList();
    }
    public class MachineService : IMachineService
    {
        private readonly AppDbContext _context;
        public MachineService(AppDbContext context)
        {
            _context = context;
        }
        public Machine Get(int id)
        {
            return _context.Machines
                .Include(m => m.MachineType)
                .Include(m => m.Storage)
                .SingleOrDefault(m => m.Id == id);
        }

        public Machine New()
        {
            return new Machine();
        }

        public bool Exists(int id)
        {
            return _context.Machines.Any(m => m.Id.Equals(id));
        }

        public async Task<Machine> GetAsync(int id)
        {
            return await _context.Machines
                .Include(m => m.MachineType)
                .Include(m => m.Storage)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public List<Machine> GetList()
        {
            return _context.Machines
                .Include(m => m.MachineType)
                .Include(m => m.Storage)
                .ToList();
        }

        public async Task<List<Machine>> GetListAsync()
        {
            return await _context.Machines
                .Include(m => m.MachineType)
                .Include(m => m.Storage)
                .ToListAsync();
        }

        public bool Create(Machine entity)
        {
            _context.Machines.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(Machine entity)
        {
            _context.Machines.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Update(Machine entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
             _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(Machine entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(Machine entity)
        {
            _context.Machines.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(Machine entity)
        {
            _context.Machines.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<MachineType> GetMachineTypeList()
        {
            return _context.MachineTypes.AsNoTracking().ToList();
        }

        public List<Storage> GetStorageList()
        {
            return _context.Storages.AsNoTracking().ToList();
        }
    }
}
