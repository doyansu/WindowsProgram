using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BindingListObject
{
    public class InventoryListRow : INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private string _bookName;
        private string _bookCategory;
        private int _bookQuantity;
        private string _bookFormatInformation;
        #endregion

        #region Constructor
        public InventoryListRow(List<string> data)
        {
            int dataMappingIndex = 0;
            this._bookName = data[dataMappingIndex++];
            this._bookCategory = data[dataMappingIndex++];
            this._bookQuantity = int.Parse(data[dataMappingIndex++]);
            this._bookFormatInformation = data[dataMappingIndex++];
        }
        #endregion

        #region Member Function
        #endregion

        #region Property
        public string BookName
        {
            get
            {
                return _bookName;
            }
        }

        public string BookCategory 
        {
            get
            {
                return _bookCategory;
            }
        }

        public int BookQuantity 
        {
            get
            {
                return _bookQuantity;
            }
        }

        public string BookFormatInformation 
        {
            get
            {
                return _bookFormatInformation;
            }
        }
        #endregion

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
