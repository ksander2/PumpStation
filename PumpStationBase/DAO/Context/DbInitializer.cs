using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PumpStationBase.Domain;

namespace PumpStationBase.DAO
{
    class DbInitializer : CreateDatabaseIfNotExists<PumpStationContext>
    {

        protected override void Seed (PumpStationContext context)
        {
            context.Months.Add(new Month { Id = 0, MonthName = "Январь" });
            context.Months.Add(new Month { Id = 1, MonthName = "Февраль" });
            context.Months.Add(new Month { Id = 2, MonthName = "Март" });
            context.Months.Add(new Month { Id = 3, MonthName = "Апрель" });
            context.Months.Add(new Month { Id = 4, MonthName = "Май" });
            context.Months.Add(new Month { Id = 5, MonthName = "Июнь" });
            context.Months.Add(new Month { Id = 6, MonthName = "Июль" });
            context.Months.Add(new Month { Id = 7, MonthName = "Август" });
            context.Months.Add(new Month { Id = 8, MonthName = "Сентябрь" });
            context.Months.Add(new Month { Id = 9, MonthName = "Октябрь" });
            context.Months.Add(new Month { Id = 10, MonthName = "Ноябрь" });
            context.Months.Add(new Month { Id = 11, MonthName = "Декабрь" });

            for (int i = 0; i < 12; i++)
            {
                context.Statements.Add(new Statement { Id = i });
            }

            context.Tariffs.Add(new Tariff { Id = 0, TariffPrice=0 });

             base.Seed(context);
        }
    }
}
