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
    public class DriverManager
    {
        // 
        // Using List<RaceCarDriver> does not work.
        // BindingList<RaceCarDriver> should be used.
        //
        BindingList<RaceCarDriver> drivers = new BindingList<RaceCarDriver>();
        //
        // Returning IBindingList is even better (remove coupling to concrete class)
        // *** TRY THE FOLLOWING CODE ***
        // public IBindingList Drivers
        //
        public BindingList<RaceCarDriver> Drivers
        {
            get { return drivers; }
        }

        public void AddDriver(string name, int wins)
        {
            drivers.Add(new RaceCarDriver(name, wins));
        }

        public void DeleteDriver(int position)
        {
            if (drivers.Count() > 0)
                drivers.RemoveAt(position);
        }

        public void AddWins(int position)
        {
            if (drivers.Count() > 0)
                drivers[position].AddWin();
        }
    }
}
