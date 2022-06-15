using System.Text.Json;

namespace Core
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default, string? rawData = null) => new(data, message, false, rawData);

        public static Response<T> Ok<T>(T data, string message = "Ok", string? rawData = null) => new(data, message, true, rawData);
    }

    public class Response<T>
    {
        public Response(T data, string msg, bool success, string? raw = null)
        {
            Data = data;
            Message = msg;
            Success = success;
            RawData = raw;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string? RawData { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
