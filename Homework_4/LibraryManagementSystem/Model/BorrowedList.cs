using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BorrowedList
    {
        private List<BorrowedItem> _borrowedItems;

        public BorrowedList()
        {
            this._borrowedItems = new List<BorrowedItem>();
        }

        #region Member Function
        // 加入已借書單
        public void Add(BorrowedItem borrowedItem)
        {
            this._borrowedItems.Add(borrowedItem);
        }

        // 清除清單資料
        public void Clear()
        {
            this._borrowedItems.Clear();
        }

        // 重新整理 BorrowedList (將數量 = 0 的 bookItem 刪除)
        public void RefreshList()
        {
            this._borrowedItems = this._borrowedItems.FindAll(content => content.BookItem.Quantity > 0);
        }

        // 取得 BOOKITEM
        public BookItem GetBookItemAt(int index)
        {
            return index >= 0 && index < this._borrowedItems.Count ? this._borrowedItems[index].BookItem : null;
        }

        // 取得資料清單
        public List<BorrowedBookInformation> GetInformationList()
        {
            List<BorrowedBookInformation> informationList = new List<BorrowedBookInformation>();
            foreach (BorrowedItem borrowedItem in this._borrowedItems)
                informationList.Add(new BorrowedBookInformation(borrowedItem));
            return informationList;
        }

        public int Count
        {
            get
            {
                return _borrowedItems.Count;
            }
        }
        #endregion
    }
}
