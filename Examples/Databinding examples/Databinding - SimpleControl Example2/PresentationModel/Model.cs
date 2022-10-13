/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     PresentationModel不含任何controls
////////////////////////////////////////////////////////////////////////////////////

namespace PresentationModel
{
    public class Model
    {
        int question_counter;
        int numberQuestions;
        
        public void Start(int numberQuestions)
        {
            this.numberQuestions = numberQuestions;
            question_counter = 1;
        }

        public void Next()
        {
            question_counter++;
        }

        public bool NoMoreQuestions()
        {
            return question_counter > numberQuestions;
        }
        
        public string GetQuestion()
        {
            if (question_counter == 0 || NoMoreQuestions())
                return string.Empty;
            return "Question (" + question_counter + ")"; 
        }
    }
}
