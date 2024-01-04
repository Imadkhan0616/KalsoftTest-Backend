namespace KALSOFT_Test.Utilities
{
    public class CustomResponse<T>
    {

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public IEnumerable<T> Data { get; set; }
    }

}
