using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookInventoryFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Library _model;
        private int _selectedRowIndex = 0;

        const string NOTIFY_SELECT_ROW_INDEX_CHANGED = "SelectedRowIndex";
        const string NOTIFY_BOOK_INFORMATION_CHANGED = "BookInformation";
        private readonly string[] _notifyList = { 
            NOTIFY_SELECT_ROW_INDEX_CHANGED,
            NOTIFY_BOOK_INFORMATION_CHANGED, };

        public BookInventoryFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.NotifyPropertyChanged;
        }

        #region 
        public int SelectedRowIndex
        {
            get
            {
                return this._selectedRowIndex;
            }
            set
            {
                if (this._selectedRowIndex != value)
                {
                    this._selectedRowIndex = value;
                    NotifyPropertyChanged(NOTIFY_SELECT_ROW_INDEX_CHANGED);
                }
            }
        }

        public string BookInformation
        {
            get
            {
                return "test";
            }
        }
        #endregion

        #region Event Invoke Function
        // 通知所有 databing 改變
        private void NotifyPropertyChanged()
        {
            foreach (string dataBinding in this._notifyList)
                this.NotifyPropertyChanged(dataBinding);
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
