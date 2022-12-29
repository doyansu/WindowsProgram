using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States
{
    interface IState
    {
        // PressPointer
        void PressPointer(double pointX, double pointY);
        // MovePointer
        void MovePointer(double pointX, double pointY);
        // ReleasePointer
        void ReleasePointer(double pointX, double pointY);
    }
}
