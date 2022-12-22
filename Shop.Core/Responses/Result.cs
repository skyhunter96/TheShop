using Shop.Core.Enums;

namespace Shop.Core.Responses
{
    public class Result
    {
        public Result()
        {
            Warnings = new List<string>();
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public ErrorType ErrorType { get; set; }
        public ICollection<string> Warnings { get; set; }

        public static Result Success() => new Result()
        {
            IsSuccessful = true
        };

        public static Result Error(string message) => new Result()
        {
            IsSuccessful = false,
            Message = message
        };
    }
}
