using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.PresentationModel;

namespace LibraryManagementSystem
{
    public partial class BackPackForm : Form
    {
        #region Event
        public event Action _updateBorrowingFormView;
        #endregion

        private BackPackFormPresentationModel _presentationModel;

        public BackPackForm(BackPackFormPresentationModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
            this._presentationModel._showMessage += ShowMessage;
            this._backPackDataGridView.CellContentClick += ClickDataGridView1CellContent;
        }

        // 更新所有 View (書包資訊)
        public void UpdateView()
        {
            this._backPackDataGridView.Rows.Clear();
            List<string[]> borrowedList = this._presentationModel.GetBorrowedListInformationList();
            foreach (string[] row in borrowedList)
                this._backPackDataGridView.Rows.Add(row);
        }

        // 顯示訊息
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        #region Form Event
        // 點擊書包的歸還按鈕
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                this._presentationModel.ClickDataGridView1CellContent(e.RowIndex);
                this.UpdateView();
                this.UpdateBorrowingFormView();
            }
        }
        #endregion

        #region Event Handle Function
        // 顯示 Message
        private void UpdateBorrowingFormView()
        {
            if (this._updateBorrowingFormView != null)
                this._updateBorrowingFormView.Invoke();
        }
        #endregion
    }
}
