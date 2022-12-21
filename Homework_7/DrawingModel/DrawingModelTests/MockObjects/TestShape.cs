using System.Collections.Generic;
using System.Linq;

namespace DrawingModel.Tests
{
    public class TestShape : Shape
    {
        public Dictionary<string, int> _invoke = new Dictionary<string, int>();

        // Draw
        public override void Draw(IGraphics graphics)
        {
            Call("Draw");
        }

        // call function
        private void Call(string key)
        {
            if (!_invoke.Keys.Contains(key))
                _invoke["Draw"] = 0;
            _invoke["Draw"] += 1;
        }
    }
}