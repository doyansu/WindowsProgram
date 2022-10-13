using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataGridDataBinding
{
    //
    // Implement INotifyPropertyChanged to support Data Binding
    //
    // If INotifyPropertyChanged is not implemented, the display of individual RaceCarDrivers cannot
    //    be updated automatically.
    // *** TRY THE FOLLOWING CODE ***
    // public class RaceCarDriver
    public class RaceCarDriver : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string name;
        int wins;
    
        public RaceCarDriver(string name, int wins)
        {
            this.name = name;
            this.wins = wins;
        }
        
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }
        
        public int Wins
        {
            get { return this.wins; }
            set
            {
                this.wins = value;
                NotifyPropertyChanged("Wins");
            }
        }
        
        public void AddWin()
        {
            wins++;
            // Don't forget to notify that the "Wins" property is changed
            NotifyPropertyChanged("Wins");
        }
        
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
