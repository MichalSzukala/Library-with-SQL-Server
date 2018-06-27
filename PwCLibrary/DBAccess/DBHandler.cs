using System.Collections.Generic;
using System.Data.SqlClient;

namespace PwCLibrary.DBAccess
{
    /// <summary>
    /// Comunicate with a DB to extract information
    /// </summary>
    public class DBHandler
    {
        private string connectionString = "Data Source=.\\SQLExpress;" +
                                          "Initial Catalog=libraryDB;" +
                                          "User id=sa;" +
                                          "Password=pwcserver;";

        /// <summary>
        /// Configure connection to DB
        /// </summary>
        /// <returns>Connection to the DB</returns>
        public SqlConnection ConnectionSettingsToDB(string connectionSettings)
        {
            SqlConnection connection = new SqlConnection(connectionSettings);
            return connection;
        }


        /// <summary>
        /// Check if the book exists in the library 
        /// </summary>
        /// <param name="bookTitle">Title of the book</param>
        /// <returns>True if library ownes that book</returns>
        public bool IsBookExisting(string bookTitle)
        {
            using (SqlConnection connection = ConnectionSettingsToDB(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT title " +
                    "FROM book " +
                    "WHERE title=@Title", connection);
                cmd.Parameters.AddWithValue("@Title", bookTitle);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }


        /// <summary>
        /// Check if book is loaned to somebody
        /// </summary>
        /// <param name="bookTitle">Title of the book</param>
        /// <returns>True if the book is loaned</returns>
        public bool IsBookLoaned(string bookTitle)
        {
            using (SqlConnection connection = ConnectionSettingsToDB(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT title " +
                    "FROM book " +
                    "WHERE id_book IN (SELECT id_book " +
                    "FROM loan) " +
                    "AND title=@Title", connection);
                cmd.Parameters.AddWithValue("@Title", bookTitle);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }


        /// <summary>
        /// Check which books are not returned on time
        /// </summary>
        /// <returns>List of books with dates that the books should be returned back to library</returns>
        public List<DelayedBook> DelayedBooks()
        {
            using (SqlConnection connection = ConnectionSettingsToDB(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT book.title, CONVERT(varchar, loan.in_date, 103) AS in_date " +
                    "FROM book " +
                    "INNER JOIN loan " +
                    "ON book.id_book=loan.id_book " +
                    "WHERE in_date<GETDATE()", connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<DelayedBook> delayedBooks = new List<DelayedBook>();
                    while (reader.Read())
                    {
                        string title = reader["title"].ToString();
                        object dueDate = reader["in_date"].ToString();
                        delayedBooks.Add(new DelayedBook(title, dueDate.ToString()));
                    }
                    return delayedBooks;
                }
            }
        }


        /// <summary>
        /// Check what is the book's return date
        /// </summary>
        /// <param name="bookTitle">Title of the book</param>
        /// <returns>The date the book should be return</returns>
        public string BookReturnDate(string bookTitle)
        {
            using (SqlConnection connection = ConnectionSettingsToDB(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT CONVERT(varchar, loan.in_date, 103) " +
                    "FROM loan " +
                    "WHERE id_book IN (SELECT id_book " +
                    "FROM book " +
                    "WHERE title=@Title)", connection);
                cmd.Parameters.AddWithValue("@Title", bookTitle);
                
                object date = cmd.ExecuteScalar();
                string dateInString = date.ToString();
                return dateInString;
            }
        }


        /// <summary>
        /// Check who borrowed the book
        /// </summary>
        /// <param name="bookTitle">Title of the book</param>
        /// <returns>Name of the person who borrowed the book</returns>
        public string BookBorrower(string bookTitle)
        {
            using (SqlConnection connection = ConnectionSettingsToDB(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT f_name, l_name " +
                    "FROM book_keeper " +
                    "WHERE id_user IN (SELECT id_user " +
                    "FROM loan " +
                    "WHERE id_book IN (SELECT id_book " +
                    "FROM book " +
                    "WHERE title=@Title))", connection);
                cmd.Parameters.AddWithValue("@Title", bookTitle);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    string f_name = reader["f_name"].ToString();
                    string l_name = reader["l_name"].ToString();
                    return f_name + " " + l_name;
                }
            }
        }
    }
}
