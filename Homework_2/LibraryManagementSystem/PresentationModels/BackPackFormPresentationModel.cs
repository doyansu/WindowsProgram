using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BackPackFormPresentationModel
    {
        private Library _presentationModel;

        public BackPackFormPresentationModel(Library presentationModel)
        {
            this._presentationModel = presentationModel;
        }
    }
}
