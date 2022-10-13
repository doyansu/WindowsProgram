using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataBinding_SimpleControl
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        bool isAddButtonEnabled = false;
        bool isEditMode = false;

        public void categoryTextBoxTextChanged(string text)
        {
            isAddButtonEnabled = text != "";
            notify("isAddButtonEnabled");
        }

        public void clickEditButton()
        {
            isEditMode = !isEditMode;
            notify("AddButtonText");
        }

        private void notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsAddButtonEnabled
        {
            get
            {
                return isAddButtonEnabled;
            }
        }

        public string AddButtonText
        {
            get
            {
                if (isEditMode)
                    return "修改";
                return "新增";
            }
        }

    }
}
