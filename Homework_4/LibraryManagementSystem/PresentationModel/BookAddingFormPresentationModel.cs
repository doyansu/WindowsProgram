using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookAddingFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Library _model;
        private int _addingQuantity = 0;
        private string _bookInformation = "";

        private readonly string[] _notifyList = { 
            "BookInformation" };

        public BookAddingFormPresentationModel(Library model)
        {
            this._model = model;
        }

        // SetAddingQuantity by string
        public void SetAddingQuantity(string quantity)
        {
            this.AddingQuantity = quantity != "" ? int.Parse(quantity) : 0;
        }

        #region Property
        public int AddingQuantity
        {
            get
            {
                return this._addingQuantity;
            }
            set
            {
                this._addingQuantity = value;
            }
        }

        public string BookInformation 
        {
            get
            {
                return this._bookInformation;
            }
            set
            {
                this._bookInformation = value;
                this.NotifyPropertyChanged();
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
