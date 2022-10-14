using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.PresentationModel.BindingListObject;

namespace LibraryManagementSystem.PresentationModel
{
    public class BackPackFormPresentationModel
    {
        #region Event
        public event Action<string> _showMessage;
        #endregion

        #region Attributes
        private Library _model;
        BindingList<BackPackBookRow> _backPackList = new BindingList<BackPackBookRow>();
        #endregion

        #region Constructor
        public BackPackFormPresentationModel(Library model)
        {
            this._model = model;
            this._model._modelChanged += this.UpdateBackPackList;
        }
        #endregion

        #region View Process
        // 點擊書包的歸還按鈕
        public void ClickDataGridView1CellContent(object rowTag)
        {
            int rowIndex = int.Parse(rowTag.ToString());
            const string MESSAGE_FORMAT = "[{0}] 已成功歸還";
            this.ShowMessage(string.Format(MESSAGE_FORMAT, this._model.GetBorrowedBookName(rowIndex)));
            this._model.ReturnBorrowedListItem(rowIndex);
        }
        #endregion

        #region Output
        // 取得書包資訊
        public void UpdateBackPackList()
        {
            List<List<string>> informationList = this._model.GetBorrowedInformationList();
            this._backPackList.Clear();
            foreach (List<string> stringList in informationList)
                this._backPackList.Add(new BackPackBookRow(stringList));
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
        private void ShowMessage(string message)
        {
            if (this._showMessage != null && message != null)
                this._showMessage.Invoke(message);
        }
        #endregion
    }
}
