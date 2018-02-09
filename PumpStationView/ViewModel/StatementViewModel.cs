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
    class StatementViewModel : BaseViewModel
    {
        private UnitOfWork _UnitOfWork;
        private Month _selectedMonth;
        private List<Month> _MonthList;
        private List<Statement> _statementList;

        private StatementView _instanceWindow;
       
        private Statement _currentStatement;
        
        private int _selectedMonthId = 0;

        public StatementViewModel(UnitOfWork UnitOfWork, StatementView view, List<Month> MonthList, int SelectMonthId)
        {
            _selectedMonthId = SelectMonthId;
            _MonthList = MonthList;
           
            _instanceWindow = view;
            _UnitOfWork = UnitOfWork;
            _statementList = _UnitOfWork.StatementDAO.getAll().ToList();
            CurentStatement = _statementList.Where(x => x.Id == _selectedMonthId).FirstOrDefault();
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
                CurentStatement = _statementList.Where(x => x.Id == _selectedMonthId).FirstOrDefault();
            }
        }
        public Statement CurentStatement
        {
            get { return _currentStatement; }
            set
            {
                _currentStatement = value;
                OnPropertyChanged("CurentStatement");
            }
        }

        public Month SelectedMoth
        {
            get { return _selectedMonth; }
            set 
            { 
                 _selectedMonth = value;
                 OnPropertyChanged("SelectedMoth");    
            }
        }

        public List<Month> MonthList
        {
            get { return _MonthList; }
        }


        #region OkCmd

        private void DoOkCmd()
        {
            foreach (Statement st in _statementList)
            {
                _UnitOfWork.StatementDAO.update(st);
            }
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
            foreach (Statement st in _statementList)
            {
                _UnitOfWork.StatementDAO.UndoChange(st);
            }
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
