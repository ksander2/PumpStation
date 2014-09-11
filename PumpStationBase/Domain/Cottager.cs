using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace PumpStationBase.Domain
{
    public partial class Cottager : EntityBase
    {
        public int Id { get; set; }

        public int MonthId { get; set; }

        [Display(Name = "ФИО дачника")]
        [Required(ErrorMessage = "Name required")]
        [StringLength(100)]
        public string Name { get; set; }

        public int GardenId { get; set; }

        public virtual Garden Garden { get; set; }

        public virtual Month Month { get; set; }
    }
}
