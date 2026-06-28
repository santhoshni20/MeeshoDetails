namespace MeeshoDetails.DTOs
{
    public class apiResponseDTO
    {
        public int statusCode { get; set; }
        public string message { get; set; } = string.Empty;
        public object? data { get; set; }
        public string? errorDetails { get; set; }
    }
}
