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
            Application.Run(new MenuForm(new MenuFormPresentationModel(), new BookBorrowingFrom(new BookBorrowingFormPresentationModel(model)), new BookInventoryForm()));
        }
    }
}
