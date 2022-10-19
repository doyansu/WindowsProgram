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
        Library _model;
        BookInventoryFormPresentationModel _presentationModel;

        #region Constructor
        public BookInventoryForm(Library model)
        {
            InitializeComponent();
            this._model = model;
            this._presentationModel = new BookInventoryFormPresentationModel(model);
            this._bookInformationDataGridView.CellPainting += this.PatingDataGridView;
            this._bookInformationDataGridView.SelectionChanged += this.ChangeDataGridViewSelection;
            this.BindData();
        }
        #endregion

        #region Private Function
        // Binding data
        private void BindData()
        {
            const string BIND_ATTRIBUTE_TEXT = "Text";
            this._bookInformationRichTextBox.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._presentationModel, "BookInformation");
            this._bookInformationDataGridView.DataSource = this._presentationModel.InventoryList;
        }
        #endregion

        #region Form Event
        // 選取範圍改變
        private void ChangeDataGridViewSelection(object sender, EventArgs e)
        {
            const string BUTTON_IMAGE_PATH_FORMAT = "../../../image/{0}.jpg";
            if (this._bookInformationDataGridView.SelectedRows.Count == 1)
            {
                var row = this._bookInformationDataGridView.SelectedRows[0];
                this._bookImageLabel.Image = Image.FromFile(string.Format(BUTTON_IMAGE_PATH_FORMAT, row.Index + 1));
                this._presentationModel.SelectedRowIndex = row.Index;
            }
        }

        // 點擊儲存格
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            // 點擊補貨按鈕
            if (e.ColumnIndex == this._addingButtonColumn.Index && e.RowIndex >= 0)
            {
                BookAddingForm bookAddingForm = new BookAddingForm(this._model);
                bookAddingForm.SetBookInformation(this._presentationModel.BookItemInformation);
                if (bookAddingForm.ShowDialog() == DialogResult.OK)
                    this._presentationModel.ClickAddingButton(bookAddingForm.GetAddingQuantity());
            }
        }

        // 繪製補貨按鈕圖片
        private void PatingDataGridView(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const string ADDING_IMAGE_PATH = "../../../image/replenishment.png";
            if (e.ColumnIndex == this._addingButtonColumn.Index && e.RowIndex >= 0)
            {
                Image image = Image.FromFile(ADDING_IMAGE_PATH);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = image.Width;
                var h = image.Height;
                var x = e.CellBounds.Left + ((e.CellBounds.Width - w) >> 1);
                var y = e.CellBounds.Top + ((e.CellBounds.Height - h) >> 1);
                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        #endregion
    }
}
