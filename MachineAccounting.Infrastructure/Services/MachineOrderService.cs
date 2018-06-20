
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineAccounting.DataContext;
using MachineAccounting.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineAccounting.Infrastructure.Services
{
    public interface IMachineOrderService : IService<MachineOrder>
    {
    }
    public class MachineOrderService : IMachineOrderService
    {
        private readonly AppDbContext _context;
        public MachineOrderService(AppDbContext context)
        {
            _context = context;
        }
        public MachineOrder Get(int id)
        {
            return _context.MachineOrders
                .Include(m => m.Machine)
                .Include(m => m.Order)
                .SingleOrDefault(m => m.Id == id);
        }

        public MachineOrder New()
        {
            return new MachineOrder();
        }

        public bool Exists(int id)
        {
            return _context.MachineOrders.Any(m => m.Id.Equals(id));
        }

        public async Task<MachineOrder> GetAsync(int id)
        {
            return await _context.MachineOrders
                .Include(m => m.Machine)
                .Include(m => m.Order)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public List<MachineOrder> GetList()
        {
            return _context.MachineOrders
                .Include(m => m.Machine)
                .Include(m => m.Order)
                .ToList();
        }

        public async Task<List<MachineOrder>> GetListAsync()
        {
            return await _context.MachineOrders
                .Include(m => m.Machine)
                .Include(m => m.Order)
                .ToListAsync();
        }

        public bool Create(MachineOrder entity)
        {
            entity.Order = new Order();
            _context.MachineOrders.Add(entity);
            var machine = _context.Machines.Find(entity.MachineId);
            machine.Rest = machine.Rest - entity.Count;
            if (machine.Rest < 0)
            {
                machine.Rest = 0;
            }

            _context.Entry(machine).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(MachineOrder entity)
        {
            entity.Order = new Order();
            _context.MachineOrders.Add(entity);
            var machine = _context.Machines.Find(entity.MachineId);
            machine.Rest = machine.Rest - entity.Count;
            if (machine.Rest < 0)
            {
                machine.Rest = 0;
            }

            _context.Entry(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Update(MachineOrder entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
             _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAsync(MachineOrder entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(MachineOrder entity)
        {
            _context.MachineOrders.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(MachineOrder entity)
        {
            _context.MachineOrders.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
