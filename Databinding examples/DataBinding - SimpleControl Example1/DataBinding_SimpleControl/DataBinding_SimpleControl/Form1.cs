using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBinding_SimpleControl
{
    public partial class Form1 : Form
    {
        PresentationModel presentationModel;
        public Form1(PresentationModel presentationModel)
        {
            this.presentationModel = presentationModel;
            InitializeComponent();
            addButton.DataBindings.Add("Enabled", presentationModel, "isAddButtonEnabled");
            addButton.DataBindings.Add("Text", presentationModel, "AddButtonText");
            addButton.Enabled = false;
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            presentationModel.categoryTextBoxTextChanged(categoryTextBox.Text);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            presentationModel.clickEditButton();
        }
    }
}
