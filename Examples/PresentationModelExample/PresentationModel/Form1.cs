/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. Form1 (view and control)不含任何邏輯
//     2. Form1自PresentationModel取得顯示所需的資訊
//     3. Form1的事件全部委派(delegate)給PresentationModel負責
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;

namespace PresentationModel
{
    public class Form1 : Form
    {
        Button start, next;
        PresentationModel pModel;
        NumericUpDown numberQuestions;
        Label question;
        
        public Form1(PresentationModel presentationModel)
        {
            this.pModel = presentationModel;

            Text = "Presentation Model";
        
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Parent = this;
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.LeftToRight;

            numberQuestions = new NumericUpDown();
            numberQuestions.Parent = flow;
            numberQuestions.Minimum = 1;
            numberQuestions.Maximum = 100;
            numberQuestions.Value = 10;

            start = new Button();
            start.Parent = flow;
            start.Text = "Start";
            start.Click += StartClickHandler;

            next = new Button();
            next.Parent = flow;
            next.Text = "Next";
            next.Click += NextClickHandler;
            
            question = new Label();
            question.Parent = flow;
            
            RefreshControls();
        }
        
        void RefreshControls()
        {
            start.Enabled = pModel.IsStartEnabled();
            next.Enabled = pModel.IsNextEnabled();
            numberQuestions.Enabled = pModel.IsNQEnabled();
            question.Text = pModel.GetQuestion();
        }
        
        void StartClickHandler(Object sender, EventArgs args)
        {
            pModel.Start((int) numberQuestions.Value);
            RefreshControls();
        }

        void NextClickHandler(Object sender, EventArgs args)
        {
            pModel.Next();
            RefreshControls();
        }
    }
}
