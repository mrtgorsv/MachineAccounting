using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineAccounting.DataContext.Models
{
    public class Request : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
        [ForeignKey(nameof(Storage))]
        public int StorageId { get; set; }

        public virtual Machine Machine { get; set; } 
        public virtual Storage Storage { get; set; } 
    }
}
