namespace SharedKernel
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool success, Error error)
        {
            if (success && error != Error.None || !success && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            }

            IsSuccess = success;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
}
