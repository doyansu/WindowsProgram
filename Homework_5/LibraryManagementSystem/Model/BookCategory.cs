﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class BookCategory
    {
        private List<Book> _bookList;
        private string _category;

        #region Constrctor
        public BookCategory(string category)
        {
            this._bookList = new List<Book>();
            this.Category = category;
        }
        #endregion

        #region Member Function
        // add book
        public void AddBook(Book book)
        {
            this._bookList.Add(book);
        }

        // check ContainBook
        public bool ContainBook(Book book)
        {
            return this._bookList.Contains(book);
        }

        // Remove book
        public void Remove(Book book)
        {
            this._bookList.Remove(book);
        }
        #endregion

        #region Getter and Setter
        public string Category 
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        // get category count
        public int GetBookCount()
        {
            return this._bookList.Count;
        }

        // get book by index
        public Book GetBookByIndex(int index)
        {
            return (index >= 0 && index < this._bookList.Count) ? this._bookList[index] : null;
        }
        #endregion
    }
}
