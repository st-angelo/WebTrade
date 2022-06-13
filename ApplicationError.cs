namespace WebTrade
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }

        public override string StackTrace
        {
            get { return null; }
        }
    }
}
