/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. PresentationModel不含任何controls
//     2. PresentationModel儲存、管理、控制control的狀態
//     3. PresentationModel將事件委派(delegate)給Model負責
////////////////////////////////////////////////////////////////////////////////////

namespace PresentationModel
{
    public class PresentationModel
    {
        bool isStartEnabled = true;
        bool isNextEnabled = false;
        bool isNQEnabled = true;
        Model model;

        public PresentationModel(Model model)
        {
            this.model = model;
        }
        
        public bool IsStartEnabled()
        {
            return isStartEnabled;
        }

        public bool IsNextEnabled()
        {
            return isNextEnabled;
        }

        public bool IsNQEnabled()
        {
            return isNQEnabled;
        }
        
        public string GetQuestion()
        {
            return model.GetQuestion();
        }

        public void Start(int numberQuestions)
        {
            isNQEnabled = false;
            isNextEnabled = true;
            isStartEnabled = false;
            model.Start(numberQuestions);
        }
        
        public void Next()
        {
            model.Next();
            if (model.NoMoreQuestions()) {
                isNQEnabled = true;
                isNextEnabled = false;
                isStartEnabled = true;        
            }
        }
    }
}
