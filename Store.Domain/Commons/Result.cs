using System.Text.Json.Serialization;

namespace Store.Domain.Commons
{
    public class Result
    {
        public bool IsSuccess { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SuccessMessage { get; }

        protected Result(bool isSuccess, string? error, string? successMessage)
        {
            IsSuccess = isSuccess;
            Error = isSuccess ? null : error
                ?? throw new ArgumentNullException(nameof(error));

            SuccessMessage = isSuccess ? successMessage : null;
        }

        public static Result Ok(string? successMessage = null)
            => new(true, null, successMessage);

        public static Result Fail(string error)
            => new(false, error, null);
    }

    public class Result<T> : Result
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Data { get; }

        private Result(bool isSuccess, string? error, string? successMessage, T? value)
            : base(isSuccess, error, successMessage)
        {
            Data = isSuccess
                ? value ?? throw new ArgumentNullException(nameof(value))
                : default!;
        }

        public static Result<T> Ok(T value, string? successMessage = null)
            => new(true, null, successMessage, value);

        public static new Result<T> Fail(string error)
            => new(false, error, null, default);
    }
}