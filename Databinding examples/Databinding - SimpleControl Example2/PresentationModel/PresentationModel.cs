/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. PresentationModel不含任何controls
//     2. PresentationModel儲存、管理、控制control的狀態
//     3. PresentationModel將事件委派(delegate)給Model負責
////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel;

namespace PresentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        bool isStartEnabled = true;
        bool isNextEnabled = false;
        bool isNQEnabled = true;
        Model model;

        public PresentationModel(Model model)
        {
            this.model = model;
        }
        
        public bool IsStartEnabled
        {
            get
            {
                return isStartEnabled;
            }
        }

        public bool IsNextEnabled
        {
            get
            {
                return isNextEnabled;
            }
        }

        public bool IsNQEnabled
        {
            get
            {
                return isNQEnabled;
            }

        }

        public string Question
        {
            get
            {
                return model.GetQuestion();
            }
        }

        public void Start(int numberQuestions)
        {
            isNQEnabled = false;
            isNextEnabled = true;
            isStartEnabled = false;
            model.Start(numberQuestions);
            NotifyPropertyChanged();
        }
        
        public void Next()
        {
            model.Next();
            if (model.NoMoreQuestions()) {
                isNQEnabled = true;
                isNextEnabled = false;
                isStartEnabled = true;
            }
            NotifyPropertyChanged();
        }

        void NotifyPropertyChanged()
        {
            NotifyPropertyChanged("IsStartEnabled");
            NotifyPropertyChanged("IsNextEnabled");
            NotifyPropertyChanged("IsNQEnabled");
            NotifyPropertyChanged("Question");
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
