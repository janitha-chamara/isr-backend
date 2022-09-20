namespace BusinessLogic.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceResponse<T> : ServiceResponse
    {
        // Success Handling
        private bool _success;

        public ServiceResponse()
        {
            Success = true;
            Messages = new List<string>();
        }

        public ServiceResponse(T response)
        {
            Response = response;
            Success = true;
        }

        public ServiceResponse(T response, string successMessage)
        {
            Response = response;
            Success = true;
            Message = successMessage;
        }

        public ServiceResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
        }

        public ServiceResponse(List<string> errorMessages)
        {
            Success = false;
            Messages = errorMessages;
        }

        public T Response { get; set; }

        public new bool Success
        {
            get => Response != null && _success;
            set => _success = value;
        }
    }

    public class ServiceResponse
    {
        // Message Handling
        private string _message;

        public ServiceResponse()
        {
            Success = true;
            Messages = new List<string>();
        }

        public ServiceResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
        }

        public ServiceResponse(string message, bool succeed)
        {
            Success = succeed;
            Message = message;
        }

        public ServiceResponse(List<string> messages, bool succeed)
        {
            Success = succeed;
            Messages = messages;
        }

        // Success Handling
        public bool Success { get; set; }

        public string Message
        {
            get => _message ?? CompileMessages();
            set => _message = value;
        }

        public List<string> Messages { get; set; }

        private string CompileMessages()
        {
            return Messages != null && Messages.Any()
                ? string.Join(';', Messages)
                : string.Empty;
        }
    }
}
