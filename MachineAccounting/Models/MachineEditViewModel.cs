using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineAccounting.Web.Models
{
    public class MachineEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rest { get; set; }

        public string Currency { get; set; }

        [Display(Name = "Тип оборудования")]
        public int MachineTypeId { get; set; }

        [Display(Name = "Склад")]
        public int StorageId { get; set; }

        public List<SelectListItem> MachineTypeList { get; set; }
        public List<SelectListItem> StorageList { get; set; }
    }
}
