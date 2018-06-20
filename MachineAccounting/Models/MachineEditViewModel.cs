using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineAccounting.Web.Models
{
    public class MachineEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Остаток")]
        public int Rest { get; set; }

        [Display(Name = "Валюта")]
        public string Currency { get; set; }

        [Display(Name = "Тип оборудования")]
        public int MachineTypeId { get; set; }

        [Display(Name = "Склад")]
        public int StorageId { get; set; }

        public List<SelectListItem> MachineTypeList { get; set; }
        public List<SelectListItem> StorageList { get; set; }
    }
}
