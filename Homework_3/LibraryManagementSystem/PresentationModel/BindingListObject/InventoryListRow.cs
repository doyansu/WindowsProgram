﻿using System;
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

        const string NOTIFY_BOOK_QUANTITY_CHANGED = "BookQuantity";
        #endregion

        #region Constructor
        public InventoryListRow(List<string> data)
        {
            int dataMappingIndex = 0;
            const int MAPPING_OFFSET = 3;
            this._bookName = data[dataMappingIndex++];
            dataMappingIndex += MAPPING_OFFSET;
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
            set
            {
                _bookName = value;
            }
        }

        public string BookCategory 
        {
            get
            {
                return _bookCategory;
            }
            set
            {
                _bookCategory = value;
            }
        }

        public int BookQuantity 
        {
            get
            {
                return _bookQuantity;
            }
            set
            {
                if (this._bookQuantity != value)
                {
                    this._bookQuantity = value;
                    NotifyPropertyChanged(NOTIFY_BOOK_QUANTITY_CHANGED);
                }
            }
        }

        public string BookFormatInformation 
        {
            get
            {
                return _bookFormatInformation;
            }
            set
            {
                _bookFormatInformation = value;
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
