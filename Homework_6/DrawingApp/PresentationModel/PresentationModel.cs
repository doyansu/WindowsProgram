using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;



namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _igraphics;
        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _igraphics = new WindowsStoreGraphicsAdaptor(canvas);
        }
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_igraphics);
        }
    }

}
