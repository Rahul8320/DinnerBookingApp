namespace DinnerBooking.Application.Common
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; } = true;
        public string? Errors { get; set; }
        public string? Message { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}