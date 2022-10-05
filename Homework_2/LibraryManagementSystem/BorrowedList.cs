using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BorrowedList
    {
        private List<BorrowedItem> _borrowedItems;

        public BorrowedList()
        {
            this._borrowedItems = new List<BorrowedItem>();
        }
    }
}
