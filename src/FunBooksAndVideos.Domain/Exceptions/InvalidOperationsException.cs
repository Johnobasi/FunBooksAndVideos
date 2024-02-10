namespace FunBooksAndVideos.Domain.Exceptions
{
    public class InvalidOperationExceptions : Exception
    {
        
        public InvalidOperationExceptions()
        {
        }

        public InvalidOperationExceptions(string message) : base(message)
        {
        }

        public InvalidOperationExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
