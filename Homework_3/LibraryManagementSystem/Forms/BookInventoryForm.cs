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

        #region Constructor
        public BookInventoryForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BookInventoryFormPresentationModel(model);
            this.BindData();
        }
        #endregion

        #region
        // Binding data
        private void BindData()
        {

        }
        #endregion

        #region Form Event

        #endregion

    }
}
