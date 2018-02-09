using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using PumpStationBase.DAO;
using PumpStationBase.Domain;
using PumpStationBase.Model;

namespace PumpStationBase.BL
{
    public class PumpStationBL
    {
        private UnitOfWork _UnitOfWork;

        public PumpStationBL(UnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateCottager(Cottager cottager, Garden garden)
        {
            cottager.Id = _UnitOfWork.CottagerDAO.GetNextId();

            garden.Id = _UnitOfWork.GardenDAO.GetNextId();

            _UnitOfWork.CottagerDAO.create(cottager);
        }

        public void DeleteCottager(Cottager cottager)
        {
            Garden garden = cottager.Garden;
            _UnitOfWork.CottagerDAO.delete(cottager);
            _UnitOfWork.GardenDAO.delete(garden);

        }

        public void EditCottager(Cottager cottager)
        {
            _UnitOfWork.CottagerDAO.update(cottager);
        }
       

        public void FeelCottagersInfoList(ObservableCollection<CottagerInfo> CottagersInfoList, int MonthId)
        {
            CottagersInfoList.Clear();
            double allSquare = 0;
            double TariffPrice = _UnitOfWork.TariffDAO.getTariff().TariffPrice;

            double counterValue = 0;

            Statement state = _UnitOfWork.StatementDAO.GetStatementByMonthId(MonthId);
            if (state.Value.HasValue) counterValue = state.Value.Value; 

            IEnumerable<Cottager> cottagers = _UnitOfWork.CottagerDAO.GetCottagersByMonthId(MonthId).ToList();
            foreach (Cottager cottager in cottagers)
            {
                allSquare += cottager.Garden.Square;
            }

            double allPrice = counterValue * TariffPrice;

          
            foreach (Cottager cottager in cottagers)
            {
                double squareCottager = cottager.Garden.Square;
                double priceCottager = (squareCottager * allPrice) / allSquare;

                double consumption = (squareCottager * counterValue) / allSquare;

                CottagerInfo info = new CottagerInfo(cottager, priceCottager, consumption, TariffPrice);
                CottagersInfoList.Add(info);
            }
         
        }
    }
}
