using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    public class SelectionState : IDrawingState
    {
        public SelectionState(Model model) : base(model)
        {

        }

        // PressPointer
        public override void PressPointer(double pointX, double pointY)
        {
            _model.SelectShape(pointX, pointY);
        }

        // MovePointer
        public override void MovePointer(double pointX, double pointY)
        {
            // do nothing
        }

        // ReleasePointer
        public override void ReleasePointer(double pointX, double pointY)
        {
            // do nothing
        }
    }
}
