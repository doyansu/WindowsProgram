using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class AppPresentationModel
    {
        Model _model;
        IGraphics _graphics;
        public AppPresentationModel(Model model, IGraphics graphics)
        {
            this._model = model;
            _graphics = graphics;
        }

        // 繪製圖形
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }
    }

}
