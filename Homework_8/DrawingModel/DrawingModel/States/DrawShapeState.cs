using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    public class DrawShapeState : IDrawingState
    {
        ShapeType _drawShapeType = ShapeType.Null;

        public DrawShapeState(Model model) : base(model)
        {

        }

        // PressPointer
        public override void PressPointer(double pointX, double pointY)
        {
            base.PressPointer(pointX, pointY);
        }

        // MovePointer
        public override void MovePointer(double pointX, double pointY)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape shape = shapeFactory.CreateShape(this._drawShapeType);
            shape.StartX = _firstPointX;
            shape.StartY = _firstPointY;
            shape.EndX = pointX;
            shape.EndY = pointY;
            _model.Hint = shape;
        }

        // ReleasePointer
        public override void ReleasePointer(double pointX, double pointY)
        {
            _model.DrawHint();
        }

        public ShapeType DrawShapeType 
        {
            get
            {
                return _drawShapeType;
            }
            set
            {
                _drawShapeType = value;
            }
        }
    }
}
