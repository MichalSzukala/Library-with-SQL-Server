using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PwCLibrary.DBAccess;

namespace PwCLibrary.View
{
    /// <summary>
    /// GUI class to perform search of the book in the library
    /// </summary>
    public partial class SearchBook : Form
    {
        private Controller.Controller controller;

        public SearchBook()
        {
            InitializeComponent();
            controller = new Controller.Controller();
            ClearLabels();
        }

        private void ClearLabels()
        {
            textBoxTitle.Clear();
            labetShowTitle.Text = String.Empty;
            labelShowAvailable.Text = String.Empty;
            labelShowDate.Text = String.Empty;
            labelShowUser.Text = String.Empty;
        }


        /// <summary>
        /// Search for the book in the library and display if book is available.  If the book is not available 
        /// user will get notification about that with the date when the book will be return and name of person who is keeping the book
        /// </summary>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            ClearLabels();
            if (title != String.Empty)
            {
                try
                {
                    if (controller.IsBookExisting(title))
                    {
                        if (controller.IsBookLoaned(title))
                        {
                            labetShowTitle.Text = title;
                            labelShowAvailable.Text = "Not Available";
                            labelShowDate.Text = "Date: " + controller.BookReturnDate(title);
                            labelShowUser.Text = "Keeped: " + controller.BookBorrower(title);
                        }
                        else
                        {
                            labetShowTitle.Text = title;
                            labelShowAvailable.Text = "Available";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Book is not in our library", "Information");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Connection to database problem", "Information");
                }
            }
            else
            {
                MessageBox.Show("Provide some Title", "Information");
            }
        }


        /// <summary>
        /// Display all books which were not returned on time
        /// </summary>
        private void buttonDelayed_Click(object sender, EventArgs e)
        {
            try
            {
                List<DelayedBook> delayedBooks = controller.DelayedBooks();
                foreach (DelayedBook book in delayedBooks)
                {
                    MessageBox.Show($"Title: {book.Title}\t Due date: {book.DueDate}", "Delayed Books");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Connection to database problem", "Information");
            }
        }
    }
}
