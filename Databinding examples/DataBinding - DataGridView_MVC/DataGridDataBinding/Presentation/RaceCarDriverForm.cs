using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridDataBinding
{
    public partial class RaceCarDriverForm : Form
    {
        DriverManager driverManager;
        Random rand = new Random();
        public RaceCarDriverForm(DriverManager model)
        {
            InitializeComponent();
            this.driverManager = model;
            // Complex data binding
            // Note: 
            //    1. model.Drivers must implement IBindingList.
            //       Otherwise, adding/deleting elements to model.Drivers will not
            //       be reflected to dataGridView1.
            //    2. All public properties of model.Drivers will be displayed in the dataGridView.
            //       You can use Designer to adjust ordering of columns and make a specific column
            //           visible/invisible. Use the following steps:
            //       Click the top right > of dataGridView -> Choose Data Source -> Add Project Data
            //           -> object -> Expand to find DriverManager -> Finish
            //       Click the top right > of dataGridView -> Choose Data Source
            //           -> Expand DriverManagerBindingSource to find Drivers
            //       Click the top right > of dataGridView -> Edit Columns -> Modify ordering and visibility
            //    3. Designer only defines the dataGridView display properties. The real data binding
            //       should be done by the following code.
            dataGridView1.DataSource = driverManager.Drivers;
        }

        private BindingManagerBase BindingManager {
            get { return BindingContext[driverManager.Drivers]; }
        }

        private void addDriverButtonClick(object sender, EventArgs e)
        {
            driverManager.AddDriver("Driver" + rand.Next(100).ToString(), rand.Next(1000));
            BindingManager.Position = BindingManager.Count - 1;
        }

        private void deleteDriverButtonClick(object sender, EventArgs e)
        {
            driverManager.DeleteDriver(BindingManager.Position);
        }

        private void addWinsButtonClick(object sender, EventArgs e)
        {
            // Bad smell: avoid driverManager.Drivers.XXX
            // *** TRY THE FOLLOWING CODE ***
            // driverManager.Drivers[BindingManager.Position].AddWin();
            driverManager.AddWins(BindingManager.Position);
        }
    }
}
