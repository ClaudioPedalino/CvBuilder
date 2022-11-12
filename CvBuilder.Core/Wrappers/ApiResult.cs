namespace CvBuilder.Core.Wrappers
{
    public class ApiResult
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }


        public static ApiResult Success(string optionalMessage = "")
        {
            return new ApiResult()
            {
                IsSuccess = true,
                Message = optionalMessage
            };
        }

        public static ApiResult Fail(string errorMessage)
        {
            return new ApiResult()
            {
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }
}
