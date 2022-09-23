﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class BookItem
    {
        public BookItem()
        {
            this._book = null;
            this._quantity = 0;
        }

        public BookItem(Book book, int quantity)
        {
            this._book = book;
            this._quantity = quantity;
        }

        // tage book form this objedct
        public BookItem TakeBookItem(int quantity)
        {
            if (this._quantity < quantity)
            {
                quantity = this._quantity;
                this._quantity = 0;
            }
            else
            {
                this._quantity -= quantity;
            }
            return new BookItem(this._book, quantity);
        }

        // getter and setter
        // get quantity
        public int GetQuantity()
        {
            return this._quantity;
        }

        // get book
        public Book GetBook()
        {
            return this._book;
        }

        // set quantity
        public void SetQuantity(int value)
        {
            this._quantity = value;
        }

        // set book
        public void SetBook(Book value)
        {
            this._book = value;
        }

        private Book _book;
        private int _quantity;
    }
}
