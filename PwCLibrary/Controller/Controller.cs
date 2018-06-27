using System.Collections.Generic;
using PwCLibrary.DBAccess;

namespace PwCLibrary.Controller
{
    /// <summary>
    /// Controller class for the library
    /// </summary>
    public class Controller
    {
        private DBHandler db;

        public Controller()
        {
            db = new DBHandler();
        }


        public bool IsBookExisting(string bookTitle)
        {
            return db.IsBookExisting(bookTitle);
        }

        public bool IsBookLoaned(string bookTitle)
        {
            return db.IsBookLoaned(bookTitle);
        }

        public string BookReturnDate(string bookTitle)
        {
            return db.BookReturnDate(bookTitle);
        }

        public List<DelayedBook> DelayedBooks()
        {
            return db.DelayedBooks();
        }

        public string BookBorrower(string bookTitle)
        {
            return db.BookBorrower(bookTitle);
        }
    }
}
