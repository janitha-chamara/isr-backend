namespace ISRAPI
{
    public class BaseResponse<T> : BaseResponse
    {


        public BaseResponse(T response)
        {
            Response = response;
            Success = true;
        }

        public BaseResponse(T response, string successMessage)
        {
            Response = response;
            Success = true;
            Message = successMessage;
        }

        public BaseResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public T Response { get; set; }
    }

    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
