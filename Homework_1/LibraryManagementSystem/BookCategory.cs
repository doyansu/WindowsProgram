﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookCategory
    {
        public BookCategory()
        {
            this._bookList = new List<Book>();
            this._category = null;
        }

        public BookCategory(string category)
        {
            this._bookList = new List<Book>();
            this._category = category;
        }

        public BookCategory(string category, List<Book> bookList)
        {
            this._bookList = bookList;
            this._category = category;
        }

        // add book
        public void AddBook(Book book)
        {
            this._bookList.Add(book);
        }

        // getter and setter
        // get quantity
        public string GetCategory()
        {
            return this._category;
        }

        // set quantity
        public void SetCategory(string value)
        {
            this._category = value;
        }

        // get category count
        public int GetCategoryCount()
        {
            return this._bookList.Count;
        }

        // get book by index
        public Book GetBookByIndex(int index)
        {
            return (index >= 0 && index < this._bookList.Count) ? this._bookList[index] : null;
        }

        private List<Book> _bookList;
        private string _category;
    }
}