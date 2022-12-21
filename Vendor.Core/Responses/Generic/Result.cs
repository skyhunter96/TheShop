using Vendor.Core.Enums;

namespace Vendor.Core.Responses.Generic
{
    public class Result<T> : Result
    {
        public T Data { get; set; }

        public static Result<T> Success(T data) => new Result<T>()
        {
            IsSuccessful = true,
            Data = data
        };

        public new static Result<T> Error(string message) => new Result<T>()
        {
            IsSuccessful = false,
            Message = message
        };

        public static Result<T> Error(string message, ErrorType errorType) => new Result<T>()
        {
            IsSuccessful = false,
            Message = message,
            ErrorType = errorType
        };
    }
}
