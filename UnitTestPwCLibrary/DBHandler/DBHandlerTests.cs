using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwCLibrary.DBAccess;


namespace UnitTestPwCLibrary.DBHandler
{
    [TestClass]
    public class DBHandlerTests
    {
        [TestMethod]
        public void ConnectionSettingsToDB_ConfigureConnectionToRealDB_ReturnsTrue()
        {
            string connectionString = "Data Source=.\\SQLExpress;" +
                                      "Initial Catalog=libraryDB;" +
                                      "User id=sa;" +
                                      "Password=pwcserver;";
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            using (SqlConnection connection = db.ConnectionSettingsToDB(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestConnectionToTestDB_ReturnsTrue()
        {
            string connectionString = "Data Source=.\\SQLExpress;" +
                                      "Initial Catalog=testDB;" +
                                      "User id=sa;" +
                                      "Password=pwcserver;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }


        [TestMethod]
        public void IsBookExisting_NoSuchBookInDB_ReturnsFalse()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            bool result = db.IsBookExisting("TestBookNotExisting");
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void IsBookExisting_BookExistInDB_ReturnsTrue()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            bool result = db.IsBookExisting("TestBookLoaned");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBookLoaned_BookIsAvailable_ReturnsFalse()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            bool result = db.IsBookLoaned("TestBookNotLoaned");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBookLoaned_BookIsNotAvailable_ReturnsTrue()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            bool result = db.IsBookLoaned("TestBookLoaned");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DelayedBooks_OneBookIsDelayed_DelayedBookAndDate()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            List<DelayedBook> delayedBook = db.DelayedBooks();
            string result = delayedBook[0].Title + " " + delayedBook[0].DueDate;
            string expected = "TestBookLoaned 01/06/2018";

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void BookReturnDate_BookIsLoaned_ReturnsTrue()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            string result = db.BookReturnDate("TestBookLoaned");
            string expected = "01/06/2018";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BookBorrower_BookIsLoaned_ReturnsNameOfBorrowe()
        {
            PwCLibrary.DBAccess.DBHandler db = new PwCLibrary.DBAccess.DBHandler();
            string result = db.BookBorrower("TestBookLoaned");
            string expected = "testFname testLname";
            Assert.AreEqual(expected, result);
        }
    }
}
