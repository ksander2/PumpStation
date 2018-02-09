using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PumpStationBase.Domain
{
    public partial class Statement : EntityBase
    {
        [Key]
        [ForeignKey("Month")]
        public int Id { get; set; }
 
        public Nullable<int> Value { get; set; }
        public virtual Month Month { get; set; }
    }
}
