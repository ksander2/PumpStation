using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationView.View;
using PumpStationBase.DAO;
using PumpStationBase.Domain;
using PumpStationBase.Model;
using PumpStationBase.BL;
using System.Collections.ObjectModel;
using Apex.MVVM;

namespace PumpStationView.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private UnitOfWork _UnitOfWork;
        private List<Month> _MonthList;

        private ObservableCollection<CottagerInfo> _CottagerInfoList;

        private int _selectedMonthId=0;

        public MainViewModel(UnitOfWork UnitOfWork)
        {
            _CottagerInfoList = new ObservableCollection<CottagerInfo>();

            _UnitOfWork = UnitOfWork;
            _MonthList = _UnitOfWork.MonthDAO.getAll().ToList();

            RefreshList(_selectedMonthId);
        }

        public int SelectedMonthId
        {
            get
            {
                return _selectedMonthId;
            }
            set
            {
                _selectedMonthId = value;
                OnPropertyChanged("SelectedMonthId");
                RefreshList(_selectedMonthId);
            }
        }

        public ObservableCollection<CottagerInfo> CottagerInfoList
        {
            get
            {
                return _CottagerInfoList;
            }

            set
            {
                _CottagerInfoList = value;
                OnPropertyChanged("CottagerInfoList");
            }
        }

        public List<Month> MonthList
        {
            get
            {
                return _MonthList;
            }
        }

        public void RefreshList(int monthId)
        {
            PumpStationBL bl = new PumpStationBL(_UnitOfWork);
            bl.FeelCottagersInfoList(_CottagerInfoList, _selectedMonthId); 
        }

        #region CottagerCmd

        private void DoCottagerCmd()
        {
            CottagerView cottagerView = new CottagerView();
            CottagerViewModel cottagerViewModel = new CottagerViewModel(_UnitOfWork, _MonthList, _selectedMonthId, cottagerView);
            cottagerView.DataContext = cottagerViewModel;

            cottagerView.ShowDialog();

            if (cottagerView.DialogResult.HasValue && cottagerView.DialogResult.Value)
            {
             
            }

            RefreshList(_selectedMonthId);

        }

        private Command cottagerCmd;

        public Command CottagerCmd
        {
            get
            {
                if( cottagerCmd == null)
                {
                    cottagerCmd = new Command(DoCottagerCmd);
                }
                return cottagerCmd;
            }
        }
        #endregion


        #region ShowStatementCmd

        private void DoShowStatementCmd()
        {
            StatementView StatementView = new StatementView();
            StatementViewModel StatementVM = new StatementViewModel(_UnitOfWork,
                                                                    StatementView, 
                                                                    _MonthList, 
                                                                    _selectedMonthId);
            StatementView.DataContext = StatementVM;

            StatementView.ShowDialog();

            if (StatementView.DialogResult.HasValue && StatementView.DialogResult.Value)
            {
                RefreshList(_selectedMonthId);
            }

        }

        private Command showStatementCmd;

        public Command ShowStatementCmd
        {
            get
            {
                if (showStatementCmd == null)
                {
                    showStatementCmd = new Command(DoShowStatementCmd);
                }
                return showStatementCmd;
            }
        }
        #endregion

        #region ShowTariffCmd

        private void DoShowTariffCmd()
        {
            TariffView tariffView = new TariffView();
            TariffViewModel TariffVM = new TariffViewModel(_UnitOfWork, tariffView);
            tariffView.DataContext = TariffVM;

            tariffView.ShowDialog();

            if (tariffView.DialogResult.HasValue && tariffView.DialogResult.Value)
            {
                RefreshList(_selectedMonthId);
            }

        }

        private Command showTariffCmd;

        public Command ShowTariffCmd
        {
            get
            {
                if (showTariffCmd == null)
                {
                    showTariffCmd = new Command(DoShowTariffCmd);
                }
                return showTariffCmd;
            }
        }
        #endregion
    }
}
