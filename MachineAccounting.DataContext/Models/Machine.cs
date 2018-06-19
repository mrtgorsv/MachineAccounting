using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineAccounting.DataContext.Models
{
    public class Machine : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rest { get; set; }

        public string Currency { get; set; }

        [ForeignKey(nameof(MachineType))]
        public int MachineTypeId { get; set; }

        [ForeignKey(nameof(Storage))]
        public int StorageId { get; set; }

        public virtual MachineType MachineType { get; set; }
        public virtual Storage Storage{ get; set; }
    }
}
