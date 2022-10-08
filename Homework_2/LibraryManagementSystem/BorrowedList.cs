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

        #region Member Function
        // 加入已借書單
        public void Add(BorrowedItem borrowedItem)
        {
            this._borrowedItems.Add(borrowedItem);
        }

        // 刪除已借書籍
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this._borrowedItems.Count)
                this._borrowedItems.RemoveAt(index);
        }

        // 取得資料清單
        public List<List<string>> GetInformationList()
        {
            List<List<string>> informationList = new List<List<string>>();
            foreach (BorrowedItem borrowedItem in this._borrowedItems)
                informationList.Add(borrowedItem.GetInformationList());
            return informationList;
        }
        #endregion
    }
}
