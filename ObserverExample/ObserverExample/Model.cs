using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ObserverExample
{
    public class Model
    {
        enum Mode
        {
            Pointer,
            Drawing
        }

        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        int mouse_x, mouse_y;
        Mode mode = Mode.Pointer;

        public void OnPaint(Graphics g)
        {
            for (int x = 0; x < 1024; x += 20)
                for (int y = 0; y < 768; y += 20)
                    g.DrawEllipse(Pens.Blue, x, y, 20, 20);
            if (mode == Mode.Drawing && mouse_x > 0)
                g.FillEllipse(Brushes.Red, mouse_x-10, mouse_y-10, 20, 20);                    
        }

        public void MouseMoveHandler(int x, int y)
        {
            mouse_x = x;
            mouse_y = y;
            if (mode == Mode.Drawing)
                NotifyObserver();
        }

        public void SetPointerMode()
        {
            mode = Mode.Pointer;
            NotifyObserver();
        }

        public void SetDrawingMode()
        {
            mode = Mode.Drawing;
            mouse_x = mouse_y = -1;
            NotifyObserver();
        }

        void NotifyObserver()
        {
            if (ModelChanged != null)
                ModelChanged();
        }
    }
}
