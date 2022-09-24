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
            this._internationalStandardBookNumber = this._name = this._author = this._publicationItem = null;
        }

        public Book(string name, string internationalStandardBookNumber, string author, string publicationItem)
        {
            this._internationalStandardBookNumber = internationalStandardBookNumber;
            this._name = name;
            this._author = author;
            this._publicationItem = publicationItem;
        }
        #endregion

        #region Member Function
        // get BookInformation Array
        public string[] GetBookInformationArray()
        {
            string[] informationList = { this._name, this._internationalStandardBookNumber, this._author, this._publicationItem };
            return informationList;
        }

        // get a format information string
        public string GetFormatInformation()
        {
            const string BOOK_NUMBER_TITLE = "編號 : ";
            const string AUTHOR_TITLE = "作者 : ";
            const char NEW_LINE = '\n';
            string information = "";

            information += this._name + NEW_LINE;
            information += BOOK_NUMBER_TITLE + this._internationalStandardBookNumber + NEW_LINE;
            information += AUTHOR_TITLE + this._author + NEW_LINE;
            information += this._publicationItem;
            return information;
        }
        #endregion

        #region Getter and Setter
        // get internationalStandardBookNumber
        public string GetInternationalStandardBookNumber()
        {
            return this._internationalStandardBookNumber;
        }

        // get name
        public string GetName()
        {
            return this._name;
        }

        // get author
        public string GetAuthor()
        {
            return this._author;
        }

        // get publicationItem
        public string GetPublicationItem()
        {
            return this._publicationItem;
        }

        // set internationalStandardBookNumber
        public void SetInternationalStandardBookNumber(string value)
        {
            this._internationalStandardBookNumber = value;
        }

        // set name
        public void SetName(string value)
        {
            this._name = value;
        }

        // set author
        public void SetAuthor(string value)
        {
            this._author = value;
        }

        // set publicationItem
        public void SetPublicationItem(string value)
        {
            this._publicationItem = value;
        }
        #endregion
    }
}
