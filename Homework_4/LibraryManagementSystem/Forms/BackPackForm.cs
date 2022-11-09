using LibraryManagementSystem.Model;
using LibraryManagementSystem.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BackPackForm : Form
    {
        #region Event
        #endregion

        #region Attributes
        private BackPackFormPresentationModel _presentationModel;
        #endregion

        #region Constrctor
        public BackPackForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BackPackFormPresentationModel(model);
            this._presentationModel._showMessage += ShowMessage;
            this._backPackDataGridView.CellValueChanged += this.ChangeCellValue;
            this._backPackDataGridView.EditingControlShowing += this.EditingControlShowing;
            this._backPackDataGridView.DataSource = this._presentationModel.BackPackList;
        }
        #endregion

        private BindingManagerBase BindingManager
        {
            get 
            { 
                return BindingContext[this._presentationModel.BackPackList]; 
            }
        }

        // 顯示訊息
        private void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        #region Form Event
        // 點擊書包的歸還按鈕
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this._returnButtonDataGridViewTextBoxColumn.Index && e.RowIndex >= 0)
                this._presentationModel.ClickDataGridView1CellContent(e.RowIndex);
        }

        // 儲存格值改變
        private void ChangeCellValue(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this._returnCountDataGridViewTextBoxColumn.Index && e.RowIndex >= 0)
                this._presentationModel.ChangeCellValue(e.RowIndex);
        }

        // 編輯模式儲存格內容改變
        private void EditTextChanged(object sender, EventArgs e)
        {
            this._backPackDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 顯示儲存格編輯模式
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged -= this.EditTextChanged;
            e.Control.TextChanged += this.EditTextChanged;
        }
        #endregion

        #region Event Invoke Function
        #endregion
    }
}
