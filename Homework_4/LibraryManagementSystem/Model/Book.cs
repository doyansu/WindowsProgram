using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Book
    {
        private string _name;
        // ISBN
        private string _internationalStandardBookNumber;
        private string _author;
        private string _publicationItem;
        private string _imagePath;

        #region Cosntrctor
        public Book(string name, string internationalStandardBookNumber, string author, string publicationItem, string imagePath)
        {
            this.InternationalStandardBookNumber = internationalStandardBookNumber;
            this.Name = name;
            this.Author = author;
            this.PublicationItem = publicationItem;
            this.ImagePath = imagePath;
        }
        #endregion

        #region Member Function
        // copy
        public Book Copy()
        {
            Book book = new Book(this.Name, this.InternationalStandardBookNumber, this.Author, this.PublicationItem, this.ImagePath);
            return book;
        }

        // get a format information string
        public string GetFormatInformation()
        {
            const string FORMAT_STRING = "{0}\n編號 : {1}\n作者 : {2}\n{3}";
            return string.Format(FORMAT_STRING, this.Name, this.InternationalStandardBookNumber, this.Author, this.PublicationItem);
        }
        #endregion

        #region Getter and Setter
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string InternationalStandardBookNumber 
        {
            get
            {
                return _internationalStandardBookNumber;
            }
            set 
            {
                _internationalStandardBookNumber = value;
            }
        }

        public string Author 
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public string PublicationItem
        {
            get
            {
                return _publicationItem;
            }
            set
            {
                _publicationItem = value;
            }
        }

        public string ImagePath 
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }
        #endregion
    }
}
