using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBinding
{
    public partial class Form1 : Form
    {
        DriverManager driverManager;
        public Form1(DriverManager driverManager)
        {
            this.driverManager = driverManager;
            InitializeComponent();
            nameTextBox.DataBindings.Add("Text", driverManager.Drivers, "Name");
            winsTextBox.DataBindings.Add("Text", driverManager.Drivers, "Wins");
        }
        private BindingManagerBase BindingManager
        {
            get { return BindingContext[driverManager.Drivers]; }
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            BindingManager.Position = 0;
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            BindingManager.Position = BindingManager.Count - 1;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            BindingManager.Position--;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            BindingManager.Position++;
        }
    }
}
