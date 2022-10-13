using System;
using System.Collections.Generic;
using System.Drawing;

namespace CommandExample
{
    public class Model
    {
        CommandManager commandManager = new CommandManager();
        List<Rectangle> list = new List<Rectangle>();
        Point ul_point, lr_point;   // 記錄圖的左上角、右下角
        bool ul_pressed = false;    // 記錄左上角按了沒
        public void OnPaint(Graphics g)
        {
            // 畫出所有的Ellipse
            foreach (Rectangle rect in list)
            {
                g.DrawEllipse(Pens.Blue, rect);
            }
            // 畫出虛線的提示
            if (ul_pressed)
            {
                Pen dashPen = new Pen(Color.Green, 1.5f);
                dashPen.DashPattern = new float[] { 3.0f, 3.0f };
                g.DrawEllipse(dashPen, new Rectangle(ul_point.X, ul_point.Y, lr_point.X - ul_point.X, lr_point.Y - ul_point.Y));
            }
        }

        public void MouseDown(Point p)
        {
            ul_pressed = true;
            ul_point = p;
            lr_point = p;
        }

        public void MouseMove(Point p)
        {
            if (ul_pressed)
                lr_point = p;
        }

        public void MouseUp(Point p)
        {
            ul_pressed = false;
            commandManager.Execute(
                new DrawCommand(this, 
                   new Rectangle(ul_point.X, ul_point.Y, p.X - ul_point.X, p.Y - ul_point.Y)));
            //如果不用command pattern的話
            //DrawShape(new Rectangle(ul_point.X, ul_point.Y, p.X - ul_point.X, p.Y - ul_point.Y));
        }

        public void DrawShape(Rectangle r)
        {
            list.Add(r);
        }

        public void DeleteShape()
        {
            list.RemoveAt(list.Count - 1);
        }

        public void Undo()
        {
            commandManager.Undo();
        }

        public void Redo()
        {
            commandManager.Redo();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return commandManager.IsUndoEnabled;
            }
        }
    }
}
