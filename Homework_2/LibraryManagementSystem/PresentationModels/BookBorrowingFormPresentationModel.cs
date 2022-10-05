using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookBorrowingFormPresentationModel
    {
        private Library _model;

        public BookBorrowingFormPresentationModel(Library model)
        {
            this._model = model;
        }
    }
}
