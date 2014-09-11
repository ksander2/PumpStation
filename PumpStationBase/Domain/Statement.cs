using System;
using System.Collections.Generic;

namespace PumpStationBase.Domain
{
    public partial class Statement : EntityBase
    {
        public int Id { get; set; }
        public int MonthId { get; set; }
        public Nullable<int> Value { get; set; }
        public virtual Month Month { get; set; }
    }
}
