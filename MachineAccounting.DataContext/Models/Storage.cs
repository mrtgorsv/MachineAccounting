using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineAccounting.DataContext.Models
{
    public class Storage : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<MachineType> MachineTypes { get; set; }
    }
}
