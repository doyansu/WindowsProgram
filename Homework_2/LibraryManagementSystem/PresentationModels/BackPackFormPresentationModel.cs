using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BackPackFormPresentationModel
    {
        private Library _model;

        public BackPackFormPresentationModel(Library model)
        {
            this._model = model;
        }

        // 取得書包資訊
        public List<string[]> GetBorrowedListInformationList()
        {
            List<List<string>> informationList = this._model.GetBorrowedInformationList();
            List<string[]> informationArray = new List<string[]>();
            const string BUTTON_VALUE = "";
            foreach (List<string> stringList in informationList)
            {
                stringList.Insert(0, BUTTON_VALUE);
                informationArray.Add(stringList.ToArray());
            }
            return informationArray;
        }
    }
}
