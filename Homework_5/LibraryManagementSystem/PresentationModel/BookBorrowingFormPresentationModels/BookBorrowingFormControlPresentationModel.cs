using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    // 處理元件屬性
    public class BookBorrowingFormControlPresentationModel
    {
        private const int BUTTONS_PER_PAGE = 3;
        private int _tabPageWidth = 0;
        private int _buttonIndex = 0;
        private int _buttonWidth = 0;
        private int _buttonHeight = 0;

        public BookBorrowingFormControlPresentationModel()
        {

        }

        #region Button Style Process
        // 取得 ButtonLocation
        public int GetButtonLocation()
        {
            return this.ButtonWidth * (this.ButtonIndex % BUTTONS_PER_PAGE);
        }

        // 設定 ButtonSize
        public void SetButtonSize(int width, int height)
        {
            if (width >= 0 && height >= 0)
            {
                this._tabPageWidth = this._buttonWidth = width;
                this._buttonHeight = height;
            }
        }
        #endregion

        #region Property
        public int TabPageWidth 
        {
            get
            {
                return _tabPageWidth;
            }
        }

        public int ButtonIndex 
        {
            get
            {
                return _buttonIndex;
            }
            set
            {
                if (value >= 0)
                    _buttonIndex = value;
            }
        }

        public int ButtonWidth 
        {
            get
            {
                int width = this._buttonWidth / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE;
                return width >= 0 ? width : 0;
            }
        }

        public int ButtonHeight 
        {
            get
            {
                const int BUTTON_HEIGHT_ZOOM = 5;
                return this._buttonHeight * (BUTTON_HEIGHT_ZOOM - 1) / BUTTON_HEIGHT_ZOOM;
            }
        }
        #endregion

    }
}
