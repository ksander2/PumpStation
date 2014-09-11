using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationView.View;
using PumpStationBase.DAO;
using PumpStationBase.Domain;
using Apex.MVVM;

namespace PumpStationView.ViewModel
{
    class TariffViewModel : BaseViewModel
    {
        private UnitOfWork _UnitOfWork;
        private TariffView _instanceWindow;

        private Tariff _Tarriff;

        public TariffViewModel(UnitOfWork UnitOfWork, TariffView view)
        {
            _UnitOfWork = UnitOfWork;
            _instanceWindow = view;
            _Tarriff = _UnitOfWork.TariffDAO.getAll().FirstOrDefault();
        }

        public Tariff Tariff
        {
            get
            {
                return _Tarriff;
            }
            set
            {
                _Tarriff = value;
                OnPropertyChanged("Tariff");
            }
        }

        #region OkCmd
        private void DoOkCmd()
        {
            _UnitOfWork.TariffDAO.update(_Tarriff);
            _UnitOfWork.Commit();
            _instanceWindow.DialogResult = true;
        }

        private Command okCmd;

        public Command OkCmd
        {
            get
            {
                if (okCmd == null)
                {
                    okCmd = new Command(DoOkCmd);
                }
                return okCmd;
            }
        }
        #endregion

        #region CancelCmd

        private void DoCancelCmd()
        {
            _UnitOfWork.TariffDAO.UndoChange(_Tarriff);
            _instanceWindow.Close();
        }

        private Command cancelCmd;

        public Command CancelCmd
        {
            get
            {
                if (cancelCmd == null)
                {
                    cancelCmd = new Command(DoCancelCmd);
                }
                return cancelCmd;
            }
        }
        #endregion
    }
}
