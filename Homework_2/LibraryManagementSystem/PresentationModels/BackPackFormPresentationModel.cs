using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BackPackFormPresentationModel
    {
        #region Event
        public event Action<string> _showMessage;
        #endregion

        private Library _model;

        public BackPackFormPresentationModel(Library model)
        {
            this._model = model;
        }

        // 取得書包資訊
        public List<string[]> GetBorrowedListInformationList()
        {
            List<List<string>> informationList = this._model.GetBorrowedInformationList();
            List<string[]> informationArray = new List<string[]>();
            const string NULL_VALUE = "";
            foreach (List<string> stringList in informationList)
            {
                stringList.Insert(0, NULL_VALUE);
                informationArray.Add(stringList.ToArray());
            }
            return informationArray;
        }

        #region View Process
        // 點擊書包的歸還按鈕
        public void ClickDataGridView1CellContent(object rowTag)
        {
            int rowIndex = int.Parse(rowTag.ToString());
            const string MESSAGE_FORMAT = "[{0}] 已成功歸還";
            this.ShowMessage(string.Format(MESSAGE_FORMAT, this._model.GetBorrowedBookName(rowIndex)));
            this._model.ReturnBorrowedBook(rowIndex);
        }
        #endregion

        #region Event Handle Function
        // 顯示 Message
        private void ShowMessage(string message)
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message);
        }
        #endregion
    }
}
