using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.PresentationModel.BookBorrowingFormPresentationModels
{
    // 處理元件屬性
    class BookBorrowingFormControlPresentationModel
    {
        private const int BUTTONS_PER_PAGE = 3;
        private int _tabPageWidth;
        private int _buttonIndex;
        private int _buttonWidth;
        private int _buttonHeight;

        public BookBorrowingFormControlPresentationModel()
        {

        }

        #region Button Style Process
        // 取得 ButtonLocation
        public int GetButtonLocation()
        {
            return (this.TabPageWidth / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE) * (this.ButtonIndex % BUTTONS_PER_PAGE);
        }

        // 設定 ButtonSize
        public void SetButtonSize(int width, int height)
        {
            this.TabPageWidth = this.ButtonWidth = width;
            this.ButtonHeight = height;
        }
        #endregion

        #region Property
        public int TabPageWidth 
        {
            get
            {
                return _tabPageWidth;
            }
            set 
            {
                _tabPageWidth = value; 
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
                _buttonIndex = value;
            }
        }

        public int ButtonWidth 
        {
            get
            {
                return this._buttonWidth / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE;
            }
            set
            {
                this._buttonWidth = value;
            }
        }

        public int ButtonHeight 
        {
            get
            {
                const int BUTTON_HEIGHT_ZOOM = 5;
                return this._buttonHeight * (BUTTON_HEIGHT_ZOOM - 1) / BUTTON_HEIGHT_ZOOM;
            }
            set
            {
                this._buttonHeight = value;
            }
        }
        #endregion

    }
}
