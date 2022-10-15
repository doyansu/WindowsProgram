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
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        #region Form Event
        // 點擊書包的歸還按鈕
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this._returnButtonDataGridViewTextBoxColumn.Index && e.RowIndex >= 0)
                this._presentationModel.ClickDataGridView1CellContent(e.RowIndex);
        }
        #endregion

        #region Event Invoke Function
        #endregion
    }
}
