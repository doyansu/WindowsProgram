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
        private int _deleteButtonLocationLeft;
        private int _deleteButtonLocationTop;
        private int _deleteButtonWidth;
        private int _deleteButtonHeight;
        private int _cellWidth;
        private int _cellHeight;

        public BookBorrowingFormControlPresentationModel()
        {

        }

        #region Button Style Process
        // 取得 ButtonLocation
        public int GetButtonLocation()
        {
            return (this.TabPageWidth / BUTTONS_PER_PAGE - BUTTONS_PER_PAGE) * (this.ButtonIndex % BUTTONS_PER_PAGE);
        }

        // 設定 DeleteButtonSize
        public void SetDeleteButtonSize(int width, int height)
        {
            this._deleteButtonWidth = width;
            this._deleteButtonHeight = height;
        }

        // 設定 Cell data
        public void SetCell(int cellLeft, int cellTop, int cellWidth, int cellHeight)
        {
            this.DeleteButtonLocationLeft = cellLeft;
            this.DeleteButtonLocationTop = cellTop;
            this._cellWidth = cellWidth;
            this._cellHeight = cellHeight;
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

        public int DeleteButtonLocationLeft 
        {
            get
            {
                return this._deleteButtonLocationLeft + ((this._cellWidth - this.DeleteButtonWidth) >> 1);
            }
            set
            {
                this._deleteButtonLocationLeft = value;
            }
        }

        public int DeleteButtonLocationTop 
        {
            get
            {
                return this._deleteButtonLocationTop + ((this._cellHeight - this._deleteButtonHeight) >> 1);
            }
            set
            {
                this._deleteButtonLocationTop = value;
            }
        }

        public int DeleteButtonWidth 
        {
            get
            {
                return _deleteButtonWidth;
            }
            set
            {
                _deleteButtonWidth = value;
            }
        }

        public int DeleteButtonHeight 
        {
            get
            {
                return _deleteButtonHeight;
            }
            set
            {
                _deleteButtonHeight = value;
            }
        }
        #endregion

    }
}
