using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    public class DrawLineState : IDrawingState
    {
        private Shape _firstShape = null;

        public DrawLineState(Model model) : base(model)
        {

        }

        // PressPointer
        public override void PressPointer(double pointX, double pointY)
        {
            base.PressPointer(pointX, pointY);
            _firstShape = _model.CheckShapeContains(_firstPointX, _firstPointY);
        }

        // MovePointer
        public override void MovePointer(double pointX, double pointY)
        {
            if (_firstShape != null)
            {
                Line line = new Line();
                line.StartShape = _firstShape;
                line.EndShape = new Rectangle(pointX, pointY, pointX, pointY);
                _model.Hint = line;
            }
        }

        // ReleasePointer
        public override void ReleasePointer(double pointX, double pointY)
        {
            if (_firstShape != null)
            {
                Line line = new Line();
                line.StartShape = _firstShape;
                line.EndShape = _model.CheckShapeContains(pointX, pointY);
                _model.Hint = line.EndShape != null ? line : null;
                _model.DrawHint();
            }
        }
    }
}
