using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineAccounting.DataContext.Models
{
    public class MachineOrder : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual Order Order { get; set; }
    }
}
