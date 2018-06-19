using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineAccounting.DataContext.Models
{
    public class MachineType : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Section))]
        public int? SectionId { get; set; }

        public Section Section { get; set; }
    }
}
