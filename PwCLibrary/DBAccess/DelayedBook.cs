namespace PwCLibrary.DBAccess
{
    /// <summary>
    /// DTO for transfering title and the date of the book 
    /// </summary>
    public class DelayedBook
    {
        public DelayedBook(string title, string dueDate)
        {
            Title = title;
            DueDate = dueDate;
        }

        public string Title
        { get; set; }

        public string DueDate
        { get; set; }
    }

}
