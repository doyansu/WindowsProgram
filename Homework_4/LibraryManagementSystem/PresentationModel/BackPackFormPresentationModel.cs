using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel.BindingListObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BackPackFormPresentationModel
    {
        #region Event
        public event Action<string, string> _showMessage;
        #endregion

        #region Attributes
        private Library _model;
        BindingList<BackPackListRow> _backPackList = new BindingList<BackPackListRow>();

        #region Message Title
        private const string TITLE_RETURN_RESULT = "歸還結果";
        private const string TITLE_RETURN_ERROR = "還書錯誤";
        #endregion
        #endregion

        #region Constructor
        public BackPackFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.UpdateBackPackList;
            this.UpdateBackPackList();
        }
        #endregion

        #region View Process
        // 點擊書包的歸還按鈕
        public void ClickDataGridView1CellContent(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < this._backPackList.Count)
            {
                int returnQuantity = this._backPackList[rowIndex].ReturnCount;
                this.ShowMessage(string.Format("[{0}] 已成功歸還{1}本", this._backPackList[rowIndex].BookName, returnQuantity), TITLE_RETURN_RESULT);
                this._model.ReturnBorrowedListItem(rowIndex, returnQuantity);
            }
        }

        // 儲存格數值改變
        public void ChangeCellValue(int rowIndex)
        {
            int returnQuantity = this._backPackList[rowIndex].ReturnCount;
            int borrowedQuantity = this._backPackList[rowIndex].BorrowedCount;
            if (returnQuantity > borrowedQuantity)
            {
                this.ShowMessage("還書數量不能超過已借數量", TITLE_RETURN_ERROR);
                this._backPackList[rowIndex].ReturnCount = borrowedQuantity;
            }
            else if (returnQuantity <= 0)
            {
                this.ShowMessage("您至少要歸還1本書", TITLE_RETURN_ERROR);
                this._backPackList[rowIndex].ReturnCount = 1;
            }
        }
        #endregion

        #region Private Function
        // 更新書包資訊
        private void UpdateBackPackList()
        {
            List<BorrowedBookInformation> informationList = this._model.GetBorrowedListInformationList();
            for (int i = informationList.Count; i < this._backPackList.Count; i++)
                this._backPackList.RemoveAt(i);
            for (int i = 0; i < informationList.Count; i++)
                if (i < this._backPackList.Count)
                    this._backPackList[i] = new BackPackListRow(informationList[i]);
                else
                    this._backPackList.Add(new BackPackListRow(informationList[i]));
        }
        #endregion

        #region Property
        public IBindingList BackPackList
        {
            get
            {
                return this._backPackList;
            }
        }
        #endregion

        #region Event Invoke Function
        // 顯示 Message
        private void ShowMessage(string message, string title = "")
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message, title);
        }
        #endregion
    }
}
