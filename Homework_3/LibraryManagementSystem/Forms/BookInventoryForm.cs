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
    public partial class BookInventoryForm : Form
    {
        BookInventoryFormPresentationModel _presentationModel;
        BookAddingForm _bookAddingForm;

        #region Constructor
        public BookInventoryForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BookInventoryFormPresentationModel(model);
            this._bookAddingForm = new BookAddingForm(model);
            this.BindData();
        }
        #endregion

        #region Private Function
        // Binding data
        private void BindData()
        {
            const string BIND_ATTRIBUTE_TEXT = "Text";
            this._bookInformationRichTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "BookInformation");
        }
        #endregion

        #region Form Event

        #endregion
        // 點擊儲存格
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
