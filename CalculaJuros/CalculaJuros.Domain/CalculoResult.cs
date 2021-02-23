namespace CalculaJuros.Domain
{
    public class CalculoResult
    {
        public bool Success { get; set; }
        public decimal? Value { get; set; }
        public string Message { get; set; }

        public static CalculoResult IsError(string message = null)
        {
            return new CalculoResult
            {
                Success = false,
                Message = message
            };
        }

        public static CalculoResult IsSuccess(decimal value, string message = null)
        {
            return new CalculoResult
            {
                Success = true,
                Value = value,
                Message = message
            };
        }
    }
}
