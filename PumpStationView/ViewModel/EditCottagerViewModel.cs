using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PumpStationView.View;
using Apex.MVVM;
using PumpStationBase.Domain;

namespace PumpStationView.ViewModel
{
    class EditCottagerViewModel : BaseViewModel
    {
      
        private Cottager _Cottager;

        private EditCottagerView _instanceWindow;

        public EditCottagerViewModel(Cottager Cottager, EditCottagerView frame)
        {
            _Cottager = Cottager;
            _instanceWindow = frame;
        }
 
        public Cottager CurrentCottager
        {
            get 
            {
                return _Cottager;
            }

            set
            {
                _Cottager = value;
                OnPropertyChanged("CurrentCottager");
            }
        }

      

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
