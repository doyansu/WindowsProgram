using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    class DrawLineState : IDrawingState
    {
        public DrawLineState(IDrawingState state) : base(state)
        {

        }

        // MovePointer
        public override void MovePointer(double pointX, double pointY)
        {
            throw new NotImplementedException();
        }

        // PressPointer
        public override void PressPointer(double pointX, double pointY)
        {
            throw new NotImplementedException();
        }

        // ReleasePointer
        public override void ReleasePointer(double pointX, double pointY)
        {
            throw new NotImplementedException();
        }
    }
}
