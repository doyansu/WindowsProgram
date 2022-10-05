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
        private BackPackFormPresentationModel _presentationModel;

        public BackPackForm(BackPackFormPresentationModel presentationModel)
        {
            InitializeComponent();
            this._presentationModel = presentationModel;
        }
    }
}
