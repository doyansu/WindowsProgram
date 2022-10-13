using System;
using System.Drawing;

namespace CommandExample
{
    class DrawCommand : ICommand
    {
        Rectangle rect;
        Model model;
        public DrawCommand(Model m, Rectangle r)
        {
            rect = r;
            model = m;
        }

        public void Execute()
        {
            model.DrawShape(rect);
        }

        public void UnExecute()
        {
            model.DeleteShape();
        }
    }
}
