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
    public partial class BookAddingForm : Form
    {
        BookAddingFormPresentationModel _presentationModel;

        public BookAddingForm(Library model)
        {
            InitializeComponent();
            this._presentationModel = new BookAddingFormPresentationModel(model);
        }
    }
}
