using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    public abstract class IDrawingState
    {
        private double _firstPointX = 0;
        private double _firstPointY = 0;

        protected IDrawingState(IDrawingState state)
        {
            this._firstPointX = state._firstPointX;
            this._firstPointY = state._firstPointY;
        }

        // PressPointer
        abstract public void PressPointer(double pointX, double pointY);
        // MovePointer
        abstract public void MovePointer(double pointX, double pointY);
        // ReleasePointer
        abstract public void ReleasePointer(double pointX, double pointY);
    }
}
