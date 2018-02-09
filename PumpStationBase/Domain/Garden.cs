using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PumpStationBase.Domain
{
    public partial class Garden : EntityBase
    {
        public Garden()
        {

        }

        [Key]
        [ForeignKey("Cottager")]
        public int Id { get; set; }
        public int Square { get; set; }
        
        public virtual Cottager Cottager { get; set; }
    }
}

