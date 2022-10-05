﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Library model = new Library();
            model.LoadsBooksData();
            BackPackForm backPackForm = new BackPackForm(new BackPackFormPresentationModel(model));
            BookBorrowingFrom bookBorrowingFrom = new BookBorrowingFrom(new BookBorrowingFormPresentationModel(model), backPackForm);
            Application.Run(new MenuForm(new MenuFormPresentationModel(), bookBorrowingFrom, new BookInventoryForm()));
        }
    }
}
