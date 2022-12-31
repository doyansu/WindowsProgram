using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    public abstract class IDrawingState
    {
        protected Model _model;
        protected double _firstPointX = 0;
        protected double _firstPointY = 0;

        protected IDrawingState(Model model)
        {
            _model = model;
        }

        // PressPointer
        virtual public void PressPointer(double pointX, double pointY)
        {
            this._firstPointX = pointX;
            this._firstPointY = pointY;
        }

        // MovePointer
        abstract public void MovePointer(double pointX, double pointY);

        // ReleasePointer
        abstract public void ReleasePointer(double pointX, double pointY);
    }
}
