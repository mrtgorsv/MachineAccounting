using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MachineAccounting.DataContext.Enums;

namespace MachineAccounting.DataContext.Models
{
    public class Order : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public OrderType OrderType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MachineOrder> MachineOrders { get; set; }
    }
}
