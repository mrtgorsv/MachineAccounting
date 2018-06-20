using System.ComponentModel.DataAnnotations;

namespace MachineAccounting.Web.Models
{
    public class MachineOrderViewModel
    {
        public int MachineId { get; set; }
        public int OrderId { get; set; }

        [Display(Name = "Наименование")]
        public string MachineName { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Валюта")]
        public string Currency { get; set; }

        [Display(Name = "Количество")]
        public int Amount { get; set; }

        [Display(Name = "Остаток")]
        public int Rest { get; set; }
    }
}
