using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        private string _name;
        // ISBN
        private string _internationalStandardBookNumber;
        private string _author;
        private string _publicationItem;

        #region Cosntrctor
        public Book()
        {
            this.InternationalStandardBookNumber = this.Name = this.Author = this.PublicationItem = null;
        }

        public Book(string name, string internationalStandardBookNumber, string author, string publicationItem)
        {
            this.InternationalStandardBookNumber = internationalStandardBookNumber;
            this.Name = name;
            this.Author = author;
            this.PublicationItem = publicationItem;
        }
        #endregion

        #region Member Function
        // get BookInformation Array
        public string[] GetInformationArray()
        {
            return new string[] { this.Name, this.InternationalStandardBookNumber, this.Author, this.PublicationItem };
        }

        // get a format information string
        public string GetFormatInformation()
        {
            const string BOOK_NUMBER_TITLE = "編號 : ";
            const string AUTHOR_TITLE = "作者 : ";
            const char NEW_LINE = '\n';
            string information = "";

            information += this.Name + NEW_LINE;
            information += BOOK_NUMBER_TITLE + this.InternationalStandardBookNumber + NEW_LINE;
            information += AUTHOR_TITLE + this.Author + NEW_LINE;
            information += this.PublicationItem;
            return information;
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
        #endregion
    }
}
