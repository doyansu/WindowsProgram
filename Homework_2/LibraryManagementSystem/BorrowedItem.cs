﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BorrowedItem
    {
        private DateTime _date;

        #region Constructor
        public BorrowedItem()
        {
            this.Date = new DateTime();
        }
        #endregion

        #region Getter and Setter
        public DateTime Date 
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        #endregion
    }
}