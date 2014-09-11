using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationBase.Domain;
using System.Windows.Input;
using Apex.MVVM;
using PumpStationView.View;
using PumpStationBase.DAO;
using PumpStationBase.BL;

namespace PumpStationView.ViewModel
{
    class CottagerViewModel: BaseViewModel
    {
        private UnitOfWork _UnitOfWork;

        private List<Cottager> _CottagerList;

        private PumpStationBL _PumpStationBL;

        private Cottager _SelectedCottager;

        private List<Month> _MothList;

        private int _selectedMonthId;

        private CottagerView _instanceWindow;

        public CottagerViewModel(UnitOfWork unitOfWork, List<Month> monthList, int monthID, CottagerView view)
        {
            _instanceWindow = view;

            _selectedMonthId = monthID;
            _UnitOfWork = unitOfWork;
            RefreshList(_selectedMonthId);
           
            _PumpStationBL = new PumpStationBL(_UnitOfWork);

            _MothList = monthList;
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

        public List<Month> MonthList
        {
            get
            {
                return _MothList;
            }
        }

       

        public Cottager SelectedCottager
        {
            get
            {
                return _SelectedCottager;
            }
            set
            {
                _SelectedCottager = value;
                OnPropertyChanged("SelectedCottager");
            }

        }
        public List<Cottager> CottagerList 
        { 
            get
            {
                return _CottagerList;
            }
            set
            {
                _CottagerList = value;
                OnPropertyChanged("CottagerList");
            }
                 
        }

        #region AddCmd

        private void DoAddCmd()
        {
            Cottager cottager = new Cottager();
            Garden newGarden = new Garden();
            cottager.Garden = newGarden;

            EditCottagerView editView = new EditCottagerView();
            EditCottagerViewModel editViewModel = new EditCottagerViewModel(cottager, editView);
            editView.DataContext = editViewModel;

            editView.ShowDialog();

            if (editView.DialogResult.HasValue && editView.DialogResult.Value)
            {
                cottager.MonthId = _selectedMonthId;
                _PumpStationBL.CreateCottager(cottager, newGarden);
                _UnitOfWork.Commit();

                RefreshList(_selectedMonthId);
            }

        }

        private Command addCmd;

        public ICommand AddCmd
        {
            get
            {
                if (addCmd == null)
                {
                    addCmd = new Command(DoAddCmd);
                }
                return addCmd;
            }
        }
        #endregion

        #region DeleteCmd
        private void DoDeleteCmd(object parameter)
        {
            if (parameter != null)
            {
                _PumpStationBL.DeleteCottager((Cottager)parameter);

                _UnitOfWork.Commit();
                RefreshList(_selectedMonthId);
            }
        }

        private ICommand deleteCmd;

        public ICommand DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new Command(DoDeleteCmd);
                }
                return deleteCmd;
            }
        }

        #endregion

        #region EditCmd
        private void DoEditCmd(object parameter)
        {
            if (parameter != null)
            {
                Cottager cottager = (Cottager)parameter;
                Garden garden = cottager.Garden;


                EditCottagerView editView = new EditCottagerView();
                EditCottagerViewModel editViewModel = new EditCottagerViewModel(cottager, editView);
                editView.DataContext = editViewModel;

                editView.ShowDialog();

                if (editView.DialogResult.HasValue && editView.DialogResult.Value)
                {
                    _PumpStationBL.EditCottager(cottager);

                    _UnitOfWork.Commit();

                    SelectedCottager = cottager;
                    RefreshList(_selectedMonthId);
                }
                else
                {
                    _UnitOfWork.GardenDAO.UndoChange(garden);
                    _UnitOfWork.CottagerDAO.UndoChange(cottager);
                    SelectedCottager = cottager;
                    RefreshList(_selectedMonthId);
                }
            }
        }

        public void RefreshList(int monthId)
        {
            if (_CottagerList != null) _CottagerList.Clear();
            CottagerList = _UnitOfWork.CottagerDAO.GetCottagersByMonthId(monthId).ToList();
        }

        private ICommand editCmd;

        public ICommand EditCmd
        {
            get
            {
                if (editCmd == null)
                {
                    editCmd = new Command(DoEditCmd);
                }
                return editCmd;
            }
        }

        #endregion

        #region OkCmd
        private void DoOkCmd()
        {
      
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
