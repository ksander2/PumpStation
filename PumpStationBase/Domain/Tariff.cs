using System;
using System.Collections.Generic;

namespace PumpStationBase.Domain
{
    public partial class Tariff : EntityBase
    {
        public int Id { get; set; }
        public int TariffPrice { get; set; }
    }
}
