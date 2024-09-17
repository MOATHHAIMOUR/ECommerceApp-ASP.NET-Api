namespace Ecommerce.Application.Common.Results
{
    public class Result<T>
    {
        private readonly T? _value;
        public bool IsSuccess { get; }
        public bool IsFailuer => !IsSuccess;

        public T Value
        {
            get
            {
                if (IsFailuer)
                    throw new InvalidOperationException("there is no value of failuer");

                return _value!;
            }

            private init => _value = value;
        }

        public CustomError? Error;

        private Result(T value)
        {
            _value = value;
            IsSuccess = true;
            Error = CustomError.None;
        }

        private Result(CustomError error)
        {
            if (error == CustomError.None)
                throw new ArgumentException("Invalid Error");
            IsSuccess = false;
            Error = error;
        }

        public static Result<T> Succsess(T value) => new(value);
        public static Result<T> Faliuer(CustomError error) => new(error);
    }
}
