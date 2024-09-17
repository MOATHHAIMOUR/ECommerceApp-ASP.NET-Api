namespace Ecommerce.Application.Common.Results
{
    public record CustomError(string ErrorCode, string Message)
    {
        private static readonly string _recordNotFound = "RecordNotFound";
        private static readonly string _validationError = "ValidationError";

        public static readonly CustomError None = new(string.Empty, string.Empty);

        public static CustomError RecordNotFound(string message) => new(_recordNotFound, message);
        public static CustomError ValidationError(string message) => new(_validationError, message);
    }
}
