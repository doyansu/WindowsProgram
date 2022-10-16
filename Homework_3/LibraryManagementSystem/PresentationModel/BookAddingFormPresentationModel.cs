using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel
{
    public class BookAddingFormPresentationModel
    {
        private Library _model;

        public BookAddingFormPresentationModel(Library model)
        {
            this._model = model;
        }
    }
}
