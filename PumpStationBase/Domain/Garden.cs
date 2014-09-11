using System;
using System.Collections.Generic;

namespace PumpStationBase.Domain
{
    public partial class Garden : EntityBase
    {
        public Garden()
        {
            this.Cottagers = new List<Cottager>();
        }

        public int Id { get; set; }
        public int Square { get; set; }
        public virtual ICollection<Cottager> Cottagers { get; set; }
    }
}
