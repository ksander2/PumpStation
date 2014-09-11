using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationBase.Domain;

namespace PumpStationBase.Model
{
    public class CottagerInfo
    {
        private Cottager _cottager;

        private double _billMoney;

        private double _consumption;

        private double _tariff;

        public CottagerInfo(Cottager cottager, double price, double cons, double tariffPrice)
        {
            _tariff = tariffPrice;
            _consumption = cons;
            _cottager = cottager;
            _billMoney = price;
        }

        public Cottager Cottager
        {
            get
            {
                return _cottager;
            }
        }

        public double BillMoney
        {
            get
            {
                return _billMoney;
            }
        }

        public double Consumption
        {
            get
            {
               return _consumption;
            }
        }

        public double Tariff
        {
            get
            {
                return _tariff;
            }
        }


    }
}
